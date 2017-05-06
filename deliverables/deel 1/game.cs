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

    //voor assenstelsel aanpassen:
    int minX = -2;
    int maxX = 2;
    int minY = -6;
    int maxY = 2;

    //deze passen we aan in de init
    int centerX = 0
        , centerY = 0;

    //voor zoomen
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
            /*
            //named x x because its x, same for y, double for loop cos it makes things easier
        for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    //x + y * screen.width zorgt voor blok locatie, wat erna komt (k + p * screen.width) is voor offset
                    //zodat het plaatje mooi gecentreerd is.
                    screen.pixels[x + y * screen.width + 200 + 50 * screen.width] = createColor(x, y, 0);
                }
            }
            */
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
            //idk why maar als ik y values met TY doe dan werken ze niet
            screen.Line(TX(rx1), TY(ry1), TX(rx2), TY(ry2), redColor);
            screen.Line(TX(rx2), TY(ry2), TX(rx3), TY(ry3), redColor);
            screen.Line(TX(rx3), TY(ry3), TX(rx4), TY(ry4), redColor);
            screen.Line(TX(rx4), TY(ry4), TX(rx1), TY(ry1), redColor);

            alpha += .01;

            //teken x- en y-as
            screen.Line(TX(minX), TY(0), TX(maxX), TY(0), whiteColor);
            screen.Line(TX(0), TY(minY), TX(0), TY(maxY), whiteColor);

            handleKeyPresses();
        }

        //createColor (with bitshifting)
        private int createColor(int r, int g, int b)
        {
            return (r << 16) + (g << 8) + b;
        }

        //centerx en y om origin te verplaatsen. Bij centerx = 0 en y = 0 krijgen we dus
        //de origin in de linker-bovenhoek van het scherm te zien.
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
            //reverse de y
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
                    //we willen niet erdoor heen kunnen zoomen, minimale zoom = 1.
                    zoom -= 1;
                }
            }

            if (KeyPress(Key.X))
            {
                zoom += 1;
            }

            //allemaal - of + zoom zodat we als we verder zijn uitgezoomd nogsteeds best snel kunnen verplaatsen van center
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

        //van stackoverflow
        public bool KeyPress(Key key)
        {
            return (keyboardState[key] && (keyboardState[key] != lastKeyboardState[key]));
        }
    }

} // namespace Template