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
        public Surface debugScreen;
        public Scene scene;
        public Camera camera;

            //initialize
	        public void Init()
	        {
                screen = new Surface(1024, 512);
                camera = new Camera();
                scene = new Scene();
                camera = new Camera();
                debug = new Debug(screen, camera, scene);
                raytracer = new Raytracer(screen, camera, scene, debug);
	        }
	        // tick: renders one frame
	        public void Tick()
	        {
                //render the scene, debug is also rendered (called from within raytracer.render)
                raytracer.Render();
	        }
    }
} // namespace Template