﻿using System;
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

            //initialize
	        public void Init()
	        {
                camera = new Camera();
                scene = new Scene();
                camera = new Camera();
                raytracer = new Raytracer(screen, camera, scene);
                debug = new Debug(screen, camera, scene);
	        }
	        // tick: renders one frame
	        public void Tick()
	        {
                    for (int i = 0; i < scene.primitives.Count; i++)
                    {
                        drawDebug(scene.primitives[i]);
                    }
	        }

            void drawDebug(Primitive p)
            {

            debug.RenderCamera();
                //draw the spheres, do nothing for planes
                if (p is Sphere)
                {
                    Sphere s = p as Sphere;
                    debug.RenderSphere(s.pos, s.radius);
                }
            }
    }

} // namespace Template