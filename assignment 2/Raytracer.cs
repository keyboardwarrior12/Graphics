using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Template;

namespace template
{
    class Raytracer
    {
        public Scene scene;
        public Camera camera;
        public Surface surface;
        //Display surface

        //we hebben ook debug hier
        public Debug debug;

        public Raytracer()
        {
            scene = new Scene();
            camera = new Camera();
            surface = new Surface(10, 10);

            //instantiate the debug too
            debug = new Debug(scene, camera, surface);
        }

        public void Render()
        {
            //Loop over the pixel using the camera
            //Generate a ray per pixel
            //Use the ray to find the nearest intersection
            //Plot the pixels
        }
    }
}
