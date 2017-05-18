using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using System.Drawing;

namespace template
{
    class Camera
    {
        //hier moet een methode komen voor alle primary rays

        //position, direction
        Vector3 pos = new Vector3(0, 0, 0);
        Vector3 dir = new Vector3(0, 0, 1);

        //for screen plane
        Point  ru, rd, ld, lu;
        //l = left, u = up, r = right, d = down
    }
}
