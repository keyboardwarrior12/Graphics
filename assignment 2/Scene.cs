using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    class Scene
    {
        public List<Primitive> primitives;
        public List<Light> lights;
        private Intersection[,] Intersections;

        //initialize here; create the primitives/lights
        public Scene()
        {
            primitives = new List<Primitive>();
            lights = new List<Light>();

            //create plane
            Plane p = new Plane(8, new Vector3(0, 1, 0), new Vector3(1, 1, 1));
            primitives.Add(p);
            
            //create spheres
            Sphere s1 = new Sphere(new Vector3(-4, 0, 4), 2.0f, new Vector3(0.25f, 1, 1));
            primitives.Add(s1); //voeg de primitive toe aan de lijst

            Sphere s2 = new Sphere(new Vector3(0, 0, 5), 2.0f, new Vector3(0.48f, 0.14f, 0.15f));
            primitives.Add(s2);

            Sphere s3 = new Sphere(new Vector3(4, 0, 4), 2.0f, new Vector3(1, 0, 0));
            primitives.Add(s3);
        }
        
        public Intersection intersect(Ray ray)
        {
            Intersection result = null;
            Intersection i;
            //loop through primitives list for each ray, detect earliest collision
            foreach (Primitive p in primitives)
            {
                i = p.intersect(ray);
                if (i != null)
                {
                    //filter out the smallest intersection, 
                    if (result == null || result.Distance < i.Distance)
                    {
                        result = i;
                    }
                }
            }

            return result;
        }
    }
}
