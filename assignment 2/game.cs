using System;
using System.IO;
using OpenTK.Input;
using OpenTK;
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
        private KeyboardState keyboardState, lastKeyboardState; //for input
        Boolean handledPress;

        float z = 3; //negative of this is the z location of the cam
        private int FOV = 90; //field of view in degrees.

        private float left, up, down, right;
        private float xlength, ylength; //length of x axis and y axis

        //initialize
        public void Init()
	        {
                screen = new Surface(1024, 512);

                float FOVfactor = z * Math.Abs((float)Math.Tan(FOV * Math.PI/360));
                camera = new Camera(- FOVfactor, FOVfactor, FOVfactor, - FOVfactor, z); 
                scene = new Scene(debug);

                left = camera.screenlu.X;
                up = camera.screenlu.Y;
                right = camera.screenru.X;
                down = camera.screenld.Y;

                xlength = Math.Abs(left) + Math.Abs(right);
                ylength = Math.Abs(up) + Math.Abs(down);

                debug = new Debug(screen, camera, scene);
                raytracer = new Raytracer(screen, camera, scene, debug);
	        }
	        // tick: renders one frame
	        public void Tick()
	        {
            //calls the render method within raytracer, debug is also rendered (called from within raytracer.render)
                raytracer.Render();
                handleKeyPresses();

                if (handledPress)
                {
                    screen.Clear(0);
                    handledPress = false;
                }
	        }

        void handleKeyPresses()
        {
            keyboardState = Keyboard.GetState();

            //keypresses
            if (KeyPress(Key.W))
            {
                camera.MoveCamZ(new Vector3(0, 0, -3));
                handledPress = true;
            }

            if (KeyPress(Key.A))
            {
                camera.MoveCamX(new Vector3(3, 0, 0));
                handledPress = true;
            }

            if (KeyPress(Key.S))
            {
                camera.MoveCamZ(new Vector3(0, 0, 3));
                handledPress = true;
            }

            if (KeyPress(Key.D))
            {
                camera.MoveCamX(new Vector3(-3, 0, 0));
                handledPress = true;
            }

            if (KeyPress(Key.Right))
            {
                camera.RotateCam(new Vector3(30, 0, 0));
                handledPress = true;
            }

            if (KeyPress(Key.Left))
            {
                camera.RotateCam(new Vector3(-30, 0, 0));
                handledPress = true;
            }

            // Store current state for next comparison;
            lastKeyboardState = keyboardState;
        }

        //returning keyboard states for keypresses
        public bool KeyPress(Key key)
        {
            return (keyboardState[key] && (keyboardState[key] != lastKeyboardState[key]));
        }
    }
} // namespace Template