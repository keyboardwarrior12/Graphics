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
        public Surface screen; //deze was eerst surfaace
        public int[] pixels;
        //Display surface

        //we hebben ook debug hier
        public Debug debug;

        public Raytracer(Surface screen)
        {
            scene = new Scene();
            camera = new Camera();
            this.screen = screen;
            //instantiate the debug too
            debug = new Debug(scene, camera, screen);

            //In de surface class worden alle pixels al opgeslagen
            pixels = screen.pixels;
        }

        public struct Ray
        {
            public float O; //Origin
            public float D; //Direction
            public float t; //distance
        };

        public void Render()
        {
            Ray ray;
            for (int i = 0; i < pixels.Length; i++)
            {
                ray.O = i;
                //ray.D = ?
                //ray.t = ? 
            }
            //for (every pixel in the camera
            //Generate a ray per pixel 
        }
    }
}
