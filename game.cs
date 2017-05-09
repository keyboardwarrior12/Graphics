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
    KeyboardState keyboardState, lastKeyboardState;
        double a = 0;
        Surface map;
        float[,] h;
        float[] vertexData;

        //deze passen we aan in de init
        int centerX = 0
        , centerY = 0;

    //voor zoomen
    int zoom = 2;

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
        }
	// tick: renders one frame
	public void Tick()
	    {
            screen.Clear(0);
            a += .01;
            handleKeyPresses();
        }

        //createColor (with bitshifting)
        private int createColor(int r, int g, int b)
        {
            return (r << 16) + (g << 8) + b;
        }

        //centerx en y om origin te verplaatsen. Bij centerx = 0 en y = 0 krijgen we dus
        //de origin in de linker-bovenhoek van het scherm te zien.
        private int TX(float x)
        {
            x += (2 * zoom) - centerX;  //offset
            x *= (screen.width / 4);    //scale
            x = x / zoom;            //zoom extra
            return (int)x;
        }

        private int TY(float y)
        {
            y += (2 * zoom) - centerY;            //offset
            y *= (screen.height / 4);            //scale
            //zoom (higher zoom = zooming out)
            y /= zoom;
            //reverse de y
            y = (screen.height - y);
            return (int)y;
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
                if (e.KeyChar == 'z')
            {
                zoom -= 1;
            }
                if (e.KeyChar == 'x')
            {
                zoom += 1;
            }
        }

        void handleKeyPresses()
        {
            keyboardState = Keyboard.GetState();

            //keypresses
            if (KeyPress(Key.Z))
            {
                if (zoom > 1)
                {
                    //we willen niet erdoor heen kunnen zoomen, minimale zoom = 1.
                    zoom -= 1;
                }
            }

            if (KeyPress(Key.X))
            {
                zoom += 1;
            }

            //allemaal - of + zoom zodat we als we verder zijn uitgezoomd nogsteeds best snel kunnen verplaatsen van center
            if (KeyPress(Key.Left))
            {
                centerX -= zoom;
            }

            if (KeyPress(Key.Right))
            {
                centerX += zoom;
            }

            if (KeyPress(Key.Down))
            {
                centerY -= zoom;
            }

            if (KeyPress(Key.Up))
            {
                centerY += zoom;
            }

            // Store current state for next comparison;
            lastKeyboardState = keyboardState;
        }

        //van stackoverflow
        public bool KeyPress(Key key)
        {
            return (keyboardState[key] && (keyboardState[key] != lastKeyboardState[key]));
        }

        public void RenderGL()
        {
            var M = Matrix4.CreatePerspectiveFieldOfView(1.6f, 1.3f, .1f, 1000);
            GL.LoadMatrix(ref M);
            GL.Translate(0, 0, -1);
            GL.Rotate(110, 1, 0, 0);
            GL.Rotate(a * 180 / 3.14159, 0, 0, 1);

            /*
            GL.Color3(0.0f, 1.0f, 1.0f);
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(-0.5f, -0.5f, 0);
            GL.Vertex3(0.5f, -0.5f, 0);
            GL.Vertex3(-0.5f, 0.5f, 0);
            GL.End();
            */

            float scale = 1/128f;
            float hscale = -1 / 4f;
            int i = 0; 
            //GL.Color3(0.0f, 1.0f, 1.0f);
            for (int y = 0; y < 127; y++)
            {
                for (int x = 0; x < 127; x++)
                {
                    float x1 = (x - 64) * scale;
                    float x2 = x1 + scale;
                    float y1 = ( y - 64) * scale;
                    float y2 = y1 + scale;

                    GL.Begin(PrimitiveType.Triangles);
                    GL.Color3(1.0f, 0.0f, 0.0f);
                    GL.Vertex3(x2, y1, h[x + 1, y] *hscale );
                    GL.Vertex3(x1, y1, h[x, y] * hscale);
                    GL.Vertex3(x1, y2, h[x, y + 1] * hscale);
                    GL.End();

                    GL.Begin(PrimitiveType.Triangles);
                    GL.Color3(0.0f, 0.0f, 1.0f);
                    GL.Vertex3(x1, y2, h[x, y + 1] * hscale);
                    GL.Vertex3(x2, y2, h[x + 1, y + 1] * hscale);
                    GL.Vertex3(x2, y1, h[x + 1, y] * hscale);
                    GL.End();
                }
            }
        }
    }

} // namespace Template