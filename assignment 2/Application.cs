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
                case '.': //go to the right //This is the >
                    break;
                case ',': //go to the left //This is the <
                    break;
            }
                
        }

        public void ChangeFOV(Camera camera)
        {

        }
    }
}
