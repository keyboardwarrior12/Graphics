using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template;
using OpenTK;

namespace template
{
    class Triangle : Primitive
    {
        public Vector3 a, b, c; 
        public Triangle(Vector3 a, Vector3 b, Vector3 c, Vector3 color, Material material)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.color = color.Normalized();
            this.material = material;
        }

        public override Intersection intersect(Ray ray)
        {
            Vector3 Cross = Vector3.Cross(b - a, c - a);
            float D = Vector3.Dot(Cross, a);
            //Not finished
            return null;
        }

        public override Vector3 getNormal(Vector3 intersectionpoint)
        {
            return Vector3.Cross(b - a, c - a); //Normal vector to the triangle
        }
    }
}
