﻿using System;
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

        public Plane(float distance, Vector3 normal, Vector3 color)
        {
            this.distance = distance;
            this.normal = normal;
            this.color = color;
        }

        public override void intersect(Ray ray)
        {
            ray.Distance = -(Vector3.Dot(ray.Origin, normal) + distance) / Vector3.Dot(ray.Dir, normal);
            Vector3 intersectionpoint = ray.Origin + ray.Distance * ray.Dir;
        }
    }
}
