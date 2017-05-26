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

        public Raytracer(Surface screen, Camera camera, Scene scene)
        {
            this.screen = screen;
            this.camera = camera;
            this.scene = scene;

            //In de surface class worden alle pixels al opgeslagen
            //Kijk even bij Plot methode in surface
            pixels = new int[screen.width, screen.height];
        }

        public void Render()
        {
            Ray ray;
            for (int x = 0; x < screen.width; x++)
            {
                for (int y = 0; y < screen.height; y++)
                {
                    ray = new Ray();
                    ray.Origin = new Vector3(x, y, 0);
                    ray.Dir = new Vector3(ray.Origin.X - camera.pos.X, ray.Origin.Y - camera.pos.Y, ray.Origin.Z - camera.pos.Z);
                    ray.Dir.Normalize();
                    //Zo'n idee moet het zijn geloof ik 
                }
            }
            //for (every pixel in the camera plane)
            //Generate a ray per pixel 
        }
    }
}
