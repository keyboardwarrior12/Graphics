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
        public int[,] pixels;
        //Display surface

        //we hebben ook debug hier
        public Debug debug;

        public Raytracer(Surface screen, Camera camera, Scene scene)
        {
            this.screen = screen;
            this.camera = camera;
            this.scene = scene;

            //In de surface class worden alle pixels al opgeslagen
            //Kijk even bij Plot methode in surface
            pixels = new int[screen.width, screen.height];
        }

        public struct Ray
        {
            public Vector3 O; //Origin
            public Vector3 D; //Direction
            public float t; //distance
        };

        public void Render()
        {
            Ray ray;
            for (int x = 0; x < screen.width; x++)
            {
                for (int y = 0; y < screen.height; y++)
                {
                    ray = new Ray();
                    ray.O = new Vector3(x, y, 0);
                    ray.D = new Vector3(x * screen.width - ray.O.X, y * screen.height - ray.O.Y, 1);
                    //Zo'n idee moet het zijn geloof ik 
                    //ray.D = ?
                }
            }
            //for (every pixel in the camera plane)
            //Generate a ray per pixel 
        }
    }
}
