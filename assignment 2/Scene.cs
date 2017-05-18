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
            Plane p = new Plane();
            //idk wat ik nog moet toevoegen aan plane
            primitives.Add(p);

            //create spheres
            Sphere s1 = new Sphere();
            s1.pos = new Vector3(-4, 0, 0);
            s1.radius = 2.0f;
            s1.color = new Vector4(1, 0, 1, 1);
            primitives.Add(s1); //voeg de primitive toe aan de lijst

            Sphere s2 = new Sphere();
            s2.pos = new Vector3(0, 0, 0);
            s2.radius = 2.0f;
            //ff aan 2 en 3 geen kleur toevoegen als test wat er gebeurt
            primitives.Add(s2);

            Sphere s3 = new Sphere();
            s3.pos = new Vector3(4, 0, 0);
            s3.radius = 2.0f;
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
