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
        public Vector3 pos = new Vector3(0, 0, -6);
        public Vector3 dir = new Vector3(0, 0, 1);

        public Vector3 screenlu; //left up
        public Vector3 screenld; //left down
        public Vector3 screenru; //right up

        //for screen plane
        public Camera()//FOV ANGLE
        {
            screenlu = new Vector3(-2, 2, 0);
            screenld = new Vector3(-2, -2, 0);
            screenru = new Vector3(2, 2, 0);
        }
    }
}
