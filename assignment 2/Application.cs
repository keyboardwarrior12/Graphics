using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template;
using OpenTK;

namespace template
{
    class Application
    {
        public Raytracer raytracer;
        public Camera camera;
        public Application(Raytracer r, Camera c)
        {
            raytracer = r;
            camera = c;
        }

        public void Render()
        {
            raytracer.Render();
        }
        
        public void KeyPressed(object sender, KeyPressEventArgs keyPEA)
        {
            switch (keyPEA.KeyChar)
            {
                case 'd': //go right
                    break;
                case 'a': //go left 
                    break;
                case 's': //go down
                    break;
                case 'w': //go up
                    break;
                case 'r': camera.RotateCam();
                    break;
            }  
        }
    }
}
