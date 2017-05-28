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
        public Application(Raytracer r)
        {
            raytracer = r;
            raytracer.Render();
        }
        
        private void KeyUp(object sender, EventArgs ea)
        {
            Vector3 camera = raytracer.camera.pos;
            Vector3 vectorUp = camera + new Vector3(1, 1, 1);
            raytracer.camera.pos = vectorUp;
        }

        private void KeyDown(object sender, EventArgs ea)
        {

        }
        //Keyboard/Mouse input
    }
}
