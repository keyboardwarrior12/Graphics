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
        public Intersection[,] Intersections;

        public Raytracer(Surface screen, Camera camera, Scene scene, Debug debug)
        {
            this.screen = screen;
            this.camera = camera;
            this.scene = scene;
            this.debug = debug;

            //In de surface class worden alle pixels al opgeslagen
            //Kijk even bij Plot methode in surface
            pixels = new int[screen.width, screen.height];
            Intersections = new Intersection[screen.width / 2, screen.height];
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
                    ray.Dir = (screenpoint - ray.Origin).Normalized();
                    //normaliseer ray for ease

                    //loop through primitives list for each ray, detect earliest collision
                    foreach (Primitive p in scene.primitives)
                    {
                        Intersection i = p.intersect(ray);
                        if (i != null)
                        {
                            //filter out the smallest intersection, 
                            if (Intersections[x, y] == null || Intersections[x,y].Distance < i.Distance)
                            {
                                Intersections[x, y] = i;
                            }
                        }
                    }

                    //if there actually is an intersection
                    if (Intersections[x,y] != null)
                    {
                        //if (y == 0 / 2 && (x & 63) == 0){
                            debug.RenderRay(ray, Intersections[x, y]);
                    }

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
