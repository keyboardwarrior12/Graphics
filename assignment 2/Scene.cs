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

        //initialize here; create the primitives/lights
        public Scene()
        {
            primitives = new List<Primitive>();
            lights = new List<Light>();

            //create plane
            Plane p = new Plane(4);
            //p.color = new Vector3(....);
            //idk wat ik nog moet toevoegen aan plane
            primitives.Add(p);

            
            //create spheres
            Sphere s1 = new Sphere(new Vector3(-4, 0, 4), 2.0f, new Vector3(255, 255, 255));
            primitives.Add(s1); //voeg de primitive toe aan de lijst

            Sphere s2 = new Sphere(new Vector3(0, 0, 5), 2.0f, new Vector3(244, 140, 150));
            primitives.Add(s2);

            Sphere s3 = new Sphere(new Vector3(4, 0, 4), 2.0f, new Vector3(100, 0, 0));
            primitives.Add(s3);
        }
        /*
        //loop over all primitives and return the closest one
        Intersection intersect()
        {
            //loop over all primitives
            //return closest intersection
        }*/
    }
}
