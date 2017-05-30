using System;
using System.IO;
using template;

namespace Template {

    class Game
    {
        // member variables
        public Raytracer raytracer;
        public Debug debug;
        public Surface screen;
        public Scene scene;
        public Camera camera;
        public Application application;

        private float left, up, down, right;
        private float xlength, ylength; //length of x axis and y axis

        //initialize
        public void Init()
	        {
                screen = new Surface(1024, 512);
                camera = new Camera();
                scene = new Scene();
                camera = new Camera();

                left = camera.screenlu.X;
                up = camera.screenlu.Y;
                right = camera.screenru.X;
                down = camera.screenld.Y;

                xlength = Math.Abs(left) + Math.Abs(right);
                ylength = Math.Abs(up) + Math.Abs(down);

                debug = new Debug(screen, camera, scene, xlength, ylength);
                raytracer = new Raytracer(screen, camera, scene, debug, xlength, ylength);
	        }
	        // tick: renders one frame
	        public void Tick()
	        {
            //render the scene, debug is also rendered (called from within raytracer.render)
                application = new Application(raytracer);
	        }
    }
} // namespace Template