using OpenTK;
using OpenTK.Input;
using System;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Template {

class Game
{
    // member variables
    public Surface screen;
    private double alpha;
    KeyboardState keyboardState, lastKeyboardState;

    //here we can change what parts of the axes we see
    int minX = -10;
    int maxX = 10;
    int minY = -10;
    int maxY = 10;

    //we change these in the init
    int centerX = 0
        , centerY = 0;

    //for zooming
    int zoom = 2;

	// initialize
	public void Init()
	{
            alpha = 0;
            
    }
	// tick: renders one frame
	public void Tick()
	{
        screen.Clear(0);
            // top left corner
            float x1 = -1, y1 = 1.0f;
            float rx1 = (float)(x1 * Math.Cos(alpha) - y1 * Math.Sin(alpha));
            float ry1 = (float)(x1 * Math.Sin(alpha) + y1 * Math.Cos(alpha));

            // top right corner
            float x2 = 1, y2 = 1.0f;
            float rx2 = (float)(x2 * Math.Cos(alpha) - y2 * Math.Sin(alpha));
            float ry2 = (float)(x2 * Math.Sin(alpha) + y2 * Math.Cos(alpha));

            // bottom right corner
            float x3 = 1, y3 = -1.0f;
            float rx3 = (float)(x3 * Math.Cos(alpha) - y3 * Math.Sin(alpha));
            float ry3 = (float)(x3 * Math.Sin(alpha) + y3 * Math.Cos(alpha));

            // bottom left corner
            float x4 = -1, y4 = -1.0f;
            float rx4 = (float)(x4 * Math.Cos(alpha) - y4 * Math.Sin(alpha));
            float ry4 = (float)(x4 * Math.Sin(alpha) + y4 * Math.Cos(alpha));


            int redColor = createColor(255, 50, 50);
            int whiteColor = createColor(255, 255, 255);
            screen.Line(TX(rx1), TY(ry1), TX(rx2), TY(ry2), redColor);
            screen.Line(TX(rx2), TY(ry2), TX(rx3), TY(ry3), redColor);
            screen.Line(TX(rx3), TY(ry3), TX(rx4), TY(ry4), redColor);
            screen.Line(TX(rx4), TY(ry4), TX(rx1), TY(ry1), redColor);

            alpha += .01;

            //draw x and y axes
            screen.Line(TX(minX), TY(0), TX(maxX), TY(0), whiteColor);
            screen.Line(TX(0), TY(minY), TX(0), TY(maxY), whiteColor);

            //draw custom lines here ( y = ax + b, color c)
            int greenColor = createColor(40, 255, 40);
            drawLine(3, 5, greenColor);

            handleKeyPresses();
        }

        //createColor (with bitshifting)
        private int createColor(int r, int g, int b)
        {
            return (r << 16) + (g << 8) + b;
        }

        //center x and y to move the O(rigin).
        private int TX(float x)
        {
            x += (2 * zoom) - centerX;  //offset
            x *= (screen.width / 4);    //scale
            x = x / zoom;            //zoom extra
            return (int)x;
        }

        private int TY(float y)
        {
            y += (2 * zoom) - centerY;            //offset
            y *= (screen.height / 4);            //scale
            //zoom (higher zoom = zooming out)
            y /= zoom;
            //reverse the y
            y = (screen.height - y);
            return (int)y;
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
                if (e.KeyChar == 'z')
            {
                zoom -= 1;
            }
                if (e.KeyChar == 'x')
            {
                zoom += 1;
            }
        }

        void handleKeyPresses()
        {
            keyboardState = Keyboard.GetState();

            //keypresses
            if (KeyPress(Key.Z))
            {
                if (zoom > 1)
                {
                    //we don't want to be able to zoom through the window, so the minimum zoom is 1
                    zoom -= 1;
                }
            }

            if (KeyPress(Key.X))
            {
                zoom += 1;
            }

            //we do -zoom or +zoom so we can move quicker when zoomed out more.
            if (KeyPress(Key.Left))
            {
                centerX -= zoom;
            }

            if (KeyPress(Key.Right))
            {
                centerX += zoom;
            }

            if (KeyPress(Key.Down))
            {
                centerY -= zoom;
            }

            if (KeyPress(Key.Up))
            {
                centerY += zoom;
            }

            // Store current state for next comparison;
            lastKeyboardState = keyboardState;
        }

        //returning keyboard states for keypresses
        public bool KeyPress(Key key)
        {
            return (keyboardState[key] && (keyboardState[key] != lastKeyboardState[key]));
        }

        //the formula is y = ax + b; c is for the color of the line (and the line formula print)
        void drawLine(int a, int b, int c)
        {
            // y for xmin (ly) and xmax (ry) for drawing
            int ly = a * minX + b;
            int ry = a * maxX + b;
            int lx = minX, rx = maxX; //left x and right x

            //if's for keeping the line within the frame
            if (ly < minY)
            {
                ly = minY;
                lx = (ly - b) / a;

            } else if (ly > maxY)
            {
                ly = maxY;
                lx = (ly - b) / a;

            } else if (ry < minY)
            {
                ry = minY;
                rx = (ry - b) / a;

            } else if (ry > maxY)
            {
                ry = maxY;
                rx = (ry - b) / a;
            }

            screen.Line(TX(lx), TY(ly), TX(rx), TY(ry), c);
            //print the line formula close to the center of the line
            //i've commented the command under here because the Print method we're given (from you) doesn't work properly
            //it's giving an index out of bounds exception.
            //screen.Print("y = " + a + "x + " + b, TX((lx + rx) / 2), TY((ly + ry) / 2), c);
        }
    }

} // namespace Template