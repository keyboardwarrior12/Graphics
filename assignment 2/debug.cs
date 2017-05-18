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

        public Debug(Scene scene, Camera camera, Surface surface)
        {
            this.scene = scene;
            this.camera = camera;
            this.surface = surface;
        }

        public void RenderSphere(Vector3 pos, float radius)
        {

            //niet efficient maar werkt voorlopig
            surface.Line((int)(pos.X + radius), (int)(pos.Z), (int)(pos.X), (int)(pos.Z + radius), 1);
            surface.Line((int)(pos.X), (int)(pos.Z + radius), (int)(pos.X - radius), (int)(pos.Z), 1);
            surface.Line((int)(pos.X - radius), (int)(pos.Z), (int)(pos.X), (int)(pos.Z - radius), 1);
            surface.Line((int)(pos.X), (int)(pos.Z - radius), (int)(pos.X + radius), (int)(pos.Z), 1);

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

        }
    }
}
