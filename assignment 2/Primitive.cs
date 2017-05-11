using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    class Primitive
    {
        //for sphere
        Vector3 pos;
        float radius;

        //for plane
        Vector3 normal;
        float distance;

        //for current stuff, we will change this once we have materials
        Vector4 color; //uses float values for r, g, b
    }
}
