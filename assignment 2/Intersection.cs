using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    class Intersection
    {
        //List with results of intersections and nearest primitives. 
        //distance, primitive, normal
        public List<Tuple<float, Primitive, float>> Intersections = new List<Tuple<float, Primitive, float>>();
        /*
         * 
        void Sphere:: IntersectSphere(Ray ray)
        {
            vec3 c = this.pos - ray.O;
            float t = dot(c, ray.D);
            vec3 q = c - t * ray.D;
            float p2 = dot(q, q);
            if (p2 > sphere.r2)
                return;
            t -= sqrt (sphere.r2 – p2);
            if((t < ray.t) && (t > 0))
                ray.t = t;
            // or: ray.t = min( ray.t, max( 0, t ) );
        } */
    }
}
