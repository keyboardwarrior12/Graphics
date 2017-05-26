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
        public Vector3 pos = new Vector3(0, 0, 0);
        public Vector3 dir = new Vector3(0, 0, 1);

        //for screen plane
        public void Plane(int l, int u, int r, int d)
        {

        }
        //l = left, u = up, r = right, d = down
    }
}
