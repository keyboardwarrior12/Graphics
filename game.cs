using System;
using System.IO;

namespace Template {

class Game
{
	// member variables
	public Surface screen;
	// initialize
	public void Init()
	{
	}
	// tick: renders one frame
	public void Tick()
	{
		screen.Clear( 0 );
		screen.Print( "hello world", 2, 2, 0xffffff );
        screen.Line(2, 20, 160, 20, 0xff0000);

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

	}

        //createColor (with bitshifting)
        private int createColor(int r, int g, int b)
        {
            return (r << 16) + (g << 8) + b;
        }
    }

} // namespace Template