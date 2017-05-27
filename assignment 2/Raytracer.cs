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
        public Debug debug;
        public int[,] pixels;
        public List<Intersection> Intersections;
        public Intersection[,] earliestIntersections;

        public Raytracer(Surface screen, Camera camera, Scene scene, Debug debug)
        {
            this.screen = screen;
            this.camera = camera;
            this.scene = scene;
            this.debug = debug;

            //In de surface class worden alle pixels al opgeslagen
            //Kijk even bij Plot methode in surface
            pixels = new int[screen.width, screen.height];
            Intersections = new List<Intersection>();
            earliestIntersections = new Intersection[screen.width, screen.height];
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
                    //sla de ray op in onze rays lijst

                    //loop through primitives list for each ray, detect earliest collision
                    for (int i = 0; i < scene.primitives.Count; i++)
                    {
                        Primitive p = scene.primitives[i];
                        p.intersect(ray);
                        Intersections.Add(new Intersection(ray.Distance, p));
                    }

                    //filter out the smallest intersection, 
                    //and clear the list for the next iteration of the loop
                    Intersection smallest = Intersections[0];
                    for (int k = 1; k < Intersections.Count; k++)
                    {
                        if (Intersections[k].Distance < smallest.Distance)
                        {
                            smallest = Intersections[k];
                        }
                    }
                    Intersections.Clear();

                    earliestIntersections[x, y] = new Intersection(smallest.Distance, smallest.Primitive);
                    //createshadowRay(ray)
                }
            }
            debug.Render();
        }

        //Vector3 I = intersection point on the sphere/plane
        void createShadowRay(Ray ray, Vector3 I)
        {
            
        }
    }
}
