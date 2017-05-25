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
        raytracer = new Raytracer(screen);
	}
	// tick: renders one frame
	public void Tick()
	{
            for (int i = 0; i < raytracer.scene.primitives.Count; i++)
            {
                drawDebug(raytracer.scene.primitives[i]);

            }
	}

        void drawDebug(Primitive p)
        {
            //draw the spheres, do nothing for planes
            if (p is Sphere)
            {
                Sphere s = p as Sphere;
                raytracer.debug.RenderSphere(s.pos, s.radius);
            }
        }
}

} // namespace Template