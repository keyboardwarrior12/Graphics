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
        public Vector3 pos; //see constructor method
        public Vector3 dir = new Vector3(0, 0, 1);

        public Vector3 screenlu; //left up
        public Vector3 screenld; //left down
        public Vector3 screenru; //right up

        public float xlength;
        public float ylength;

        //for screen plane
        public Camera(float left, float up, float right, float down, float z)//FOV ANGLE
        {
            screenlu = new Vector3(left, up, 0);
            screenld = new Vector3(left, down, 0);
            screenru = new Vector3(right, up, 0);

            xlength = Math.Abs(left) + Math.Abs(right);
            ylength = Math.Abs(up) + Math.Abs(down);
            //with the 2 above formulas, the debug view can keep looking pretty nice
            //till values of about xlength = 40 and ylength = 40, which is more than
            //enough zoom.

            //make cam always start in the middle
            pos = new Vector3(0 , 0, -z); //xlength/2 doesnt work
            //(ylength) / 2 isn't nice.
        }
    }
}
