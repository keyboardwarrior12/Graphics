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

        private float xlength, ylength; //length of x axis and y axis

        public Raytracer(Surface screen, Camera camera, Scene scene, Debug debug, float xlength, float ylength)
        {
            this.screen = screen;
            this.camera = camera;
            this.scene = scene;
            this.debug = debug;

            this.xlength = xlength;
            this.ylength = ylength;

            //In de surface class worden alle pixels al opgeslagen
            //Kijk even bij Plot methode in surface
            pixels = new int[screen.width, screen.height];

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
                    Vector3 screenpoint = new Vector3(xlength * ((float)x/(screen.width/2)) - 2f, 
                        ylength * ((float)y/screen.height) - 2f , 0); //z is 0, op slack zeiden ze 1
                    //maar bij ons is 0 goed

                    ray = new Ray();
                    ray.Origin = camera.pos;
                    ray.Dir = (screenpoint - ray.Origin).Normalized();
                    //normaliseer ray so length is 1


                    Vector3 color;
                    if (y == 256 && (x % 63) == 0)
                    {
                        color = trace(ray, 6, true);
                    }
                    else
                    {
                        color = trace(ray, 6, false);
                    }
                    screen.Plot(x, y, debug.createColor(color));

                    //createshadowRay(ray)


                }
            }
            debug.Render();
        }

        private Vector3 trace(Ray r, int depth, bool isDebugRay)
        {
            if (depth == 0) {
                return Vector3.Zero;
            }

            Intersection i = scene.intersect(r);

            if(isDebugRay && i != null) debug.RenderRay(r, i);

            if (i == null)
            {
                return Vector3.Zero;
            }
            else //if there is actually an intersection
            {
                return i.Primitive.color;
            }

            
            //Intersect, in scene.Intersect(deze returned closest intersection)

            //If null, black

            //If reflective:
            //Start nieuwe ray als reflection (trace(new ray, depth - 1))

            //If diffuse:
            //Start ray richting light source (traceIllumination())
        }

        //Vector3 I = intersection point on the sphere/plane
        void createShadowRay(Ray ray, Vector3 I)
        {
            
        }
    }
}
