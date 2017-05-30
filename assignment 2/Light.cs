using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    class Light
    {
        public Vector3 intensity; //float values for r, g, b
        public Vector3 pos;

        public Light(Vector3 intensity, Vector3 pos)
        {
            this.intensity = intensity;
            this.pos = pos;
        }
    }
}
