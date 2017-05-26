using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace template
{
    class Debug
    {
        public Scene scene;
        public Camera camera;
        public Surface surface;
        //Display surface

        int zoom = 1;

        public Debug(Surface surface, Camera camera, Scene scene)
        {
            this.scene = scene;
            this.camera = camera;
            this.surface = surface;
        }

        public void RenderSphere(Vector3 pos, float radius)
        {

            //niet efficient maar werkt voorlopig
            surface.Line(TX(pos.X + radius), TY(pos.Z), TX(pos.X), TY(pos.Z + radius), 0xFFDDAA);
            surface.Line(TX(pos.X), TY(pos.Z + radius), TX(pos.X - radius), TY(pos.Z), 0xFFDDAA);
            surface.Line(TX(pos.X - radius), TY(pos.Z), TX(pos.X), TY(pos.Z - radius), 0xFFDDAA);
            surface.Line(TX(pos.X), TY(pos.Z - radius), TX(pos.X + radius), TY(pos.Z), 0xFFDDAA);

            //Loop over the pixel using the camera
            //Generate a ray per pixel
            //Use the ray to find the nearest intersection
            //Plot the pixels
        }

        public void RenderLight()
        {

        }

        public void RenderCamera()
        {
            surface.Plot(TX(camera.pos.X), TY(camera.pos.Y), 0xFFFFFF);
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
