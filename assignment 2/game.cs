using System;
using System.IO;
using template;

namespace Template {

class Game
{
    // member variables
    public Raytracer raytracer;
    public Surface screen;

    //initialize
	public void Init()
	{
        raytracer = new Raytracer();
	}
	// tick: renders one frame
	public void Tick()
	{
            for (int i = 0; i < raytracer.scene.primitives.Count; i++)
            {
                drawDebug(raytracer.scene.primitives[i]);

            }
            screen.Line(2, 4, 300, 600, 2000044);
	}

        void drawDebug(Primitive p)
        {
            //draw the spheres, do nothing for planes
            if (p is Sphere)
            {
                raytracer.debug.RenderSphere(p.pos, p.radius);
            }
        }
}

} // namespace Template