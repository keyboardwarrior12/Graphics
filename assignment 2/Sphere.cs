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

        public Sphere(Vector3 pos, float radius, Vector3 color, Material material)
        {
            this.pos = pos;
            this.radius = radius;
            this.color = color.Normalized();
            this.material = material;
        }

        public override Intersection intersect(Ray ray)
        {
            //note: this only works for rays that start outside the sphere
            Vector3 c = pos - ray.Origin;
            float distanceTravelled = Vector3.Dot(c, ray.Dir);
            Vector3 q = c - distanceTravelled * ray.Dir;
            float pSquare = Vector3.Dot(q, q);

            if (pSquare > (radius * radius))
            {
                return null;
            }

            distanceTravelled -= (float)Math.Sqrt((radius * radius) - pSquare);

            if (distanceTravelled < 0) return null;

            return new Intersection(distanceTravelled, this, getNormal(ray.Origin + (ray.Dir * distanceTravelled)));
        }

        public override Vector3 getNormal(Vector3 intersectionpoint)    //sphere normal calculator
        {
            return (intersectionpoint - pos);
        }
    }
}
