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
        Scene scene = new Scene();
        Camera camera = new Camera();
        Surface surface;
        //Display surface

        public Raytracer()
        {
            surface = new Surface(50, 50);
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
