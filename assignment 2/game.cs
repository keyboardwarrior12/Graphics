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
                camera = new Camera(-6, 6, 6, -6); 
                scene = new Scene();

                left = camera.screenlu.X;
                up = camera.screenlu.Y;
                right = camera.screenru.X;
                down = camera.screenld.Y;

                xlength = Math.Abs(left) + Math.Abs(right);
                ylength = Math.Abs(up) + Math.Abs(down);

                debug = new Debug(screen, camera, scene);
                raytracer = new Raytracer(screen, camera, scene, debug);

                application = new Application(raytracer, camera);
	        }
	        // tick: renders one frame
	        public void Tick()
	        {
            //calls the render method within raytracer, debug is also rendered (called from within raytracer.render)
                application.Render();
	        }
    }
} // namespace Template