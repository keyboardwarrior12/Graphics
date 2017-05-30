using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    class Intersection
    {
        public float Distance;
        public Primitive Primitive;
        public Vector3 normal;

        public Intersection(float distance, Primitive primitive, Vector3 normal)
        {
            Distance = distance;
            Primitive = primitive;
            this.normal = normal;
        }
    }
}
