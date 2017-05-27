using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    class Plane : Primitive
    {
        public Vector3 normal;
        public float distance;

        public Plane(float distance)
        {
            this.distance = distance;
        }

        public override void intersect(Ray ray)
        {
            ray.Distance = -(Vector3.Dot(ray.Origin, normal) + distance) / Vector3.Dot(ray.Dir, normal);
            Vector3 intersectionpoint = ray.Origin + ray.Distance * ray.Dir;
        }
    }
}
