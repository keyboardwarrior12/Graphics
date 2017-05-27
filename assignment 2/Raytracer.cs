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
            earliestIntersections = new Intersection[screen.width / 2, screen.height];
        }

        public void Render()
        {
            //for (every pixel in the camera plane), find the color
            //reuse the same ray
            Ray ray;
            for (int x = 0; x < 512; x++) //screen width = 512, maar client width = 1024 (want debug scherm rechts)
            {
                for (int y = 0; y < 512; y++)
                {
                    //add the z calculations here once we have a working rotating camera
                    Vector3 screenpoint = new Vector3(4 * (x/(screen.width/2)) - 2f, 
                        4 * (y/screen.height) - 2f , 1);

                    ray = new Ray();
                    ray.Origin = camera.pos;
                    ray.Dir = screenpoint - ray.Origin;
                    ray.Dir *= 100000000; //make the ray length epicly high
                    //normaliseer ray for ease

                    //loop through primitives list for each ray, detect earliest collision
                    foreach (Primitive p in scene.primitives)
                    {
                        p.intersect(ray);
                        Intersections.Add(new Intersection(ray.Distance, p));
                    }

                    //filter out the smallest intersection, 
                    //and clear the list for the next iteration of the loop
                    Intersection smallest = Intersections[0];
                    foreach(Intersection i in Intersections)
                    {
                        if ((i.Distance < smallest.Distance) && (i.Distance > 0))
                        {
                            smallest = i;
                        }
                    }
                    
                    earliestIntersections[x, y] = new Intersection(smallest.Distance, smallest.Primitive);

                    if (y == 0 / 2 && (x & 63) == 0 && smallest.Distance > 0) {
                    debug.RenderRay(ray, smallest);
                    }
                    Intersections.Clear();
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
