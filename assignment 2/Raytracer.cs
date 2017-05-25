using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Template;

namespace template
{
    class Raytracer
    {
        public Scene scene;
        public Camera camera;
        public Surface screen; //deze was eerst surfaace
        public int[,] pixels;
        //Display surface

        //we hebben ook debug hier
        public Debug debug;

        public Raytracer(Surface screen)
        {
            scene = new Scene();
            camera = new Camera();
            this.screen = screen;
            pixels = new int[screen.width, screen.height];
            //instantiate the debug too
            debug = new Debug(scene, camera, screen);
        }


        public void Render()
        {
            for (int y = 0; y < height; y++)
        }
    }
}
