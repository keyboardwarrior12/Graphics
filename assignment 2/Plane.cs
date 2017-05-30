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
        public float distance; //distance to the plane origin

        public Plane(float distance, Vector3 normal, Vector3 color, Material material)
        {
            this.distance = distance;
            this.normal = normal;
            this.color = color.Normalized();
            this.material = material;
        }

        public override Intersection intersect(Ray ray)
        {
            if (Vector3.Dot(ray.Dir, normal) > float.Epsilon)
            {
                return null;
            } else
            {
                float rayDistance = -(Vector3.Dot(ray.Origin, normal) + distance) / Vector3.Dot(ray.Dir, normal);

                if (rayDistance < 0) return null;

                return new Intersection(rayDistance, this, getNormal(ray.Origin + (ray.Dir * rayDistance)));
            }
        }

        public override Vector3 getNormal(Vector3 intersectionpoint)    //plane normal is altijd normal
        {
            return normal;
        }
    }
}
