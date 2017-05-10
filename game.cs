using OpenTK;
using OpenTK.Input;
using System;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Template {

    class Game
    {
        // member variables
        public Surface screen;
        double a = 0;
        Surface map;
        float[,] h;
        float[] vertexData;
        int VBO, vbo_pos, vbo_col;

        int programID, vsID, fsID, attribute_vpos, attribute_vcol, uniform_mview;

        // initialize
        public void Init()
        {
            map = new Surface("../../assets/heightmap.png");
            h = new float[128, 128];
            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    h[x, y] = ((float)(map.pixels[x + y * 128] & 255)) / 256;
                }
            }
            vertexData = new float[127 * 127 * 2 * 3 * 3];

            int i = 0;
            float scale = 1 / 128f;
            float hscale = -1 / 4f;
            //we couldn't think of a better method so we're using this.
            for (int y = 0; y < 127; y++)
            {
                for (int x = 0; x < 127; x++)
                {
                    float x1 = (x - 64) * scale;
                    float x2 = x1 + scale;
                    float y1 = (y - 64) * scale;
                    float y2 = y1 + scale;

                    //we save the triangle coordinates as: xyz xyz xyz..... this is the first triangle
                    vertexData[i] = x2;
                    vertexData[i + 1] = y1;
                    vertexData[i + 2] = h[x + 1, y] * hscale;
                    vertexData[i + 3] = x1;
                    vertexData[i + 4] = y1;
                    vertexData[i + 5] = h[x, y] * hscale;
                    vertexData[i + 6] = x1;
                    vertexData[i + 7] = y2;
                    vertexData[i + 8] = h[x, y + 1] * hscale;

                    //second triangle coordinates
                    vertexData[i + 9] = x1;
                    vertexData[i + 10] = y2;
                    vertexData[i + 11] = h[x, y + 1] * hscale;
                    vertexData[i + 12] = x2;
                    vertexData[i + 13] = y2;
                    vertexData[i + 14] = h[x + 1, y + 1] * hscale;
                    vertexData[i + 15] = x2;
                    vertexData[i + 16] = y1;
                    vertexData[i + 17] = h[x + 1, y] * hscale;
                    i += 18;
                }
            }

            //link the shaders with the text files
            programID = GL.CreateProgram();
            LoadShader("../../shaders/vs.glsl", ShaderType.VertexShader,
                programID, out vsID);
            LoadShader("../../shaders/fs.glsl", ShaderType.FragmentShader,
                programID, out fsID);
            GL.LinkProgram(programID);

            attribute_vpos = GL.GetAttribLocation(programID, "vPosition");
            attribute_vcol = GL.GetAttribLocation(programID, "vColor");
            uniform_mview = GL.GetUniformLocation(programID, "M");

            //this whole part is for the buffer to work
            vbo_pos = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_pos);
            GL.BufferData<float>(BufferTarget.ArrayBuffer,
            (IntPtr)(vertexData.Length * 4), vertexData, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(attribute_vpos, 3, VertexAttribPointerType.Float, false, 0, 0);

            vbo_col = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_col);
            GL.BufferData<float>(BufferTarget.ArrayBuffer,
            (IntPtr)(vertexData.Length * 4), vertexData, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(attribute_vcol, 3, VertexAttribPointerType.Float, false, 0, 0);

            //Bind the array with the buffer
            VBO = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr)(vertexData.Length * 4),
                vertexData, BufferUsageHint.StaticDraw
            );
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(3, VertexPointerType.Float, 12, 0);
        }
	// tick: renders one frame
	public void Tick()
	    {
            screen.Clear(0);
            a += .01;
        }

        //createColor (with bitshifting)
        private int createColor(int r, int g, int b)
        {
            return (r << 16) + (g << 8) + b;
        }

        public void RenderGL()
        {
            //Code that was needed before exercise 9
            /* 
            var M = Matrix4.CreatePerspectiveFieldOfView(1.6f, 1.3f, .1f, 1000);
            GL.LoadMatrix(ref M);
            GL.Translate(0, 0, -1);
            GL.Rotate(110, 1, 0, 0);
            GL.Rotate(a * 180 / 3.14159, 0, 0, 1);
            
            GL.Color3(.5f, 1f, .8f);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.DrawArrays(
            PrimitiveType.Triangles, 0, 127 * 127 * 2 * 3);
            */

            Matrix4 M = Matrix4.CreateFromAxisAngle(new Vector3(0, 0, 1), (float)a);
            M *= Matrix4.CreateFromAxisAngle(new Vector3(1, 0, 0), 1.9f);
            M *= Matrix4.CreateTranslation(0, 0,-1);
            M *= Matrix4.CreatePerspectiveFieldOfView(1.6f, 1.3f, .1f, 1000);

            GL.UseProgram(programID);
            GL.UniformMatrix4(uniform_mview, false, ref M);

            GL.EnableVertexAttribArray(attribute_vpos);
            GL.EnableVertexAttribArray(attribute_vcol);
            //the array is filled correctly. We can now draw the triangles
            GL.DrawArrays(PrimitiveType.Triangles, 0, 127 * 127 * 2 *3);
        }

        //loading the shader
        void LoadShader(String name, ShaderType type, int program, out int ID)
        {
            ID = GL.CreateShader(type);
            using (StreamReader sr = new StreamReader(name))
                GL.ShaderSource(ID, sr.ReadToEnd());
            GL.CompileShader(ID);
            GL.AttachShader(program, ID);
            Console.WriteLine(GL.GetShaderInfoLog(ID));
        }
    }
} // namespace Template