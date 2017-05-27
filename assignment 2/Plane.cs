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

        public void intersectPlane(Ray ray)
        {
            /*
            ray.Distance = -(ray.Origin * normal + distance) / (ray.Dir * normal);
             = ray.Origin + ray.Distance * ray.Dir;*/
        }
    }
}
