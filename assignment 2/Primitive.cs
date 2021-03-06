﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    abstract class Primitive
    {
        //for current stuff, we will change this once we have materials
        public Vector3 color; //uses float values for r, g, b
        public Material material;

        public abstract Intersection intersect(Ray ray);
        public abstract Vector3 getNormal(Vector3 intersectionpoint);
    }
}
