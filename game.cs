using System;
using System.IO;

namespace Template {

class Game
{
	// member variables
	public Surface screen;
    private double alpha;

        //voor assenstelsel aanpassen:
        int minX = -2;
        int maxX = 2;
        int minY = -6;
        int maxY = 2;

        //deze passen we aan in de init
        int centerX = 2
            , centerY = 2;

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
		//screen.Print( "hello world", 2, 2, 0xffffff );
        //screen.Line(2, 20, 160, 20, 0xff0000);

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
            //add view center offset
            x += (2 * zoom) - centerX;
            //scale
            x *= (screen.width / 4);
            //zoom function
            x = x / zoom;
            return (int)x;
        }

        private int TY(float y)
        {
            //offset
            y += (2 * zoom) - centerY;
            //scale
            y *= (screen.height / 4);
            //zoom (higher zoom = zooming out)
            y /= zoom;
            //reverse de y
            y = (screen.height - y);
            return (int)y;
        }
    }

} // namespace Template