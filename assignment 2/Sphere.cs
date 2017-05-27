using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    class Sphere : Primitive
    {
        public Vector3 pos;
        public float radius;

        public Sphere()
        {
        }

        public void intersectSphere(Ray ray)
        {
            //note: this only works for rays that start outside the sphere
            Vector3 c = pos - ray.Origin;
            float distanceTravelled = Vector3.Dot(c, ray.Dir);
            Vector3 q = c - distanceTravelled * ray.Dir;
            float pSquare = Vector3.Dot(q, q);

            if (pSquare > (radius * radius))
            {
                return;
            }

            distanceTravelled -= (float)Math.Sqrt((radius * radius) - pSquare);

            if ((distanceTravelled < ray.Distance) && (distanceTravelled > 0))
            {
                ray.Distance = distanceTravelled;
            }
        }
    }
}
