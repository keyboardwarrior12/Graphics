using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;
using System.Drawing;

namespace template
{
    class Debug
    {
        public Scene scene;
        public Camera camera;
        public Surface surface;
        //Display surface

        int zoom = 5;

        public Debug(Surface surface, Camera camera, Scene scene)
        {
            this.scene = scene;
            this.camera = camera;
            this.surface = surface;
        }

        public void Render()
        {
            RenderCamera();

            for (int i = 0; i < scene.primitives.Count; i++)
            {
                RenderPrimitive(scene.primitives[i]);
            }
        }

        public void RenderPrimitive(Primitive p)
        {
            //draw the spheres, do nothing for planes
            if (p is Sphere)
            {
                Sphere s = p as Sphere;
                RenderSphere(s.pos, s.radius);
            }
            else
            {
                Plane pl = p as Plane;
                RenderPlane(pl.distance, pl.color);
            }
        }

        public void RenderSphere(Vector3 pos, float radius)
        {
            /*
            //niet efficient maar werkt voorlopig
            surface.Line(TX(pos.X + radius), TY(pos.Z), TX(pos.X), TY(pos.Z + radius), 0xFFDDAA);
            surface.Line(TX(pos.X), TY(pos.Z + radius), TX(pos.X - radius), TY(pos.Z), 0xFFDDAA);
            surface.Line(TX(pos.X - radius), TY(pos.Z), TX(pos.X), TY(pos.Z - radius), 0xFFDDAA);
            surface.Line(TX(pos.X), TY(pos.Z - radius), TX(pos.X + radius), TY(pos.Z), 0xFFDDAA);
            */
            float x1, x2, z1, z2;
            
            //draw 90 lines for each circle
            for (int i = 0; i < 360; i+=4)
            {
                x1 = (float)(pos.X + radius * Math.Cos(i * Math.PI / 180));
                z1 = (float)(pos.Z + radius * Math.Sin(i * Math.PI / 180));
                x2 = (float)(pos.X + radius * Math.Cos((i + 4) * Math.PI / 180));
                z2 = (float)(pos.Z + radius * Math.Sin((i + 4) * Math.PI / 180));

                surface.Line(TX(x1), TY(z1), TX(x2), TY(z2), 0xFFDDaa);
            }
        }

        public void RenderLight()
        {

        }

        public void RenderCamera()
        {
            surface.Plot(TX(camera.pos.X), TY(camera.pos.Z), 0xFFFFFF);
        }

        public void RenderPlane(float distance, Vector3 color)
        {
            surface.Line(TX(-3), TY(camera.pos.Z + distance), TX(3), TY(camera.pos.Z + distance), 0xFFFFFF);
        }

        //translations
        private int TX(float x)
        {
            x += (2 * zoom);  //offset //centerX = 0 dus niet -0 want dat is wasted psace
            x *= (surface.width / 4);    //scale
            x = x / zoom;            //zoom extra
            return (int)x;
        }

        private int TY(float y)
        {
            y += (2 * zoom);            //offset //normaal - centerY maar die is 0 bij ons
            y *= (surface.height / 4);            //scale
            //zoom (higher zoom = zooming out)
            y /= zoom;
            //reverse the y
            y = (surface.height - y);
            return (int)y;
        }

    }
}
