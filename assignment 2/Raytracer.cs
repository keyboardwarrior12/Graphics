using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Template;

namespace template
{
    struct Ray
    {
        public Vector3 Origin;
        // ray origin
        public Vector3 Dir;
        // ray direction
        public float Distance;
        // distance
    };

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
            //for (every pixel in the camera plane), find the color
            //reuse the same ray
            Ray ray;
            for (int x = 0; x < screen.width; x++)
            {
                for (int y = 0; y < screen.height; y++)
                {
                    ray = new Ray();
                    ray.Origin = new Vector3(x, y, 0);
                    ray.Dir = new Vector3(ray.Origin.X - camera.pos.X, ray.Origin.Y - camera.pos.Y, ray.Origin.Z - camera.pos.Z);
                    ray.Dir.Normalize();
                    intersect(ray);
                }
            }
        }

        void intersect(Ray ray)
        {
            //loop through primitives list for each ray, detect earliest collision
            for (int i = 0; i < scene.primitives.Count; i++)
            {
                Primitive p = scene.primitives[i];
                //formulas of the lectures will be here
                if (p is Sphere)
                {
                    Sphere s = p as Sphere;
                }
                else
                {
                    Plane pl = p as Plane;
                }
            }
        }
    }
}
