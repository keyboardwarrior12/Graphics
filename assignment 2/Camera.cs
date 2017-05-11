using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    class Camera
    {
        //position, direction
        Vector3 pos = new Vector3(0, 0, 0);
        Vector3 dir = new Vector3(0, 0, 1);

        //for screen plane
        int lu, ld, ru, rd;
        //l = left, u = up, r = right, d = down
    }
}
