using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;
using System.Drawing;

namespace template
{
    class Debug
    {
        public Scene scene;
        public Camera camera;
        public Surface surface;
        //Display surface

        private float planewidthx, planewidthy;
        public int zoom = 5;

        public Debug(Surface surface, Camera camera, Scene scene)
        {
            this.scene = scene;
            this.camera = camera;
            this.surface = surface;

            int x = surface.width;

            //beide gewoon 4 gehouden zodat debug scherm lekker groot blijft, ook al is je 3d view heel klein
            planewidthx = 4 + (camera.xlength /4);//camera.xlength;
            planewidthy = 4 + (camera.ylength /4);//camera.ylength;
        }

        public void Render()
        {
            RenderCamera();
            RenderScreenPlane(camera.screenlu, camera.screenru);

            for (int i = 0; i < scene.primitives.Count; i++)
            {
                RenderPrimitive(scene.primitives[i]);
            }

            foreach(Light light in scene.lights)
            {
                RenderLight(light);
            }
        }

        public void RenderPrimitive(Primitive p)
        {
            //draw the spheres, do nothing for planes
            if (p is Sphere)
            {
                Sphere s = p as Sphere;
                RenderSphere(s.pos, s.radius, p);
            }
            else
            {
                /*Plane pl = p as Plane;
                RenderPlane(pl.distance, pl.color);*/
            }
        }

        public void RenderSphere(Vector3 pos, float radius, Primitive p)
        {
            float x1, x2, z1, z2;
            
            //draw 90 lines for each circle
            for (int i = 0; i < 360; i+=4)
            {
                x1 = (float)(pos.X + radius * Math.Cos(i * Math.PI / 180));
                z1 = (float)(pos.Z + radius * Math.Sin(i * Math.PI / 180));
                x2 = (float)(pos.X + radius * Math.Cos((i + 4) * Math.PI / 180));
                z2 = (float)(pos.Z + radius * Math.Sin((i + 4) * Math.PI / 180));

                surface.Line(TX(x1), TY(z1), TX(x2), TY(z2), createColor(p.color));
            }
        }

        public void RenderLight(Light light)
        {
            float lightx = light.pos.X;
            float lightz = light.pos.Z;

            float x = .3f, z = .3f;

            surface.Line(TX(lightx + x), TY(lightz), TX(lightx), TY(lightz - z), 0x00FF00);
            surface.Line(TX(lightx), TY(lightz - z), TX(lightx - x), TY(lightz), 0x00FF00);
            surface.Line(TX(lightx - x), TY(lightz), TX(lightx), TY(lightz + z), 0x00FF00);
            surface.Line(TX(lightx), TY(lightz + z), TX(lightx + x), TY(lightz), 0x00FF00);
            //make a green rectangle laying on it's side for each light
        }

        //for when there is a collision
        public void RenderRay(Ray ray, Intersection intersection)
        {
            Vector3 intersectionpoint = ray.Origin + (intersection.Distance * ray.Dir);
            surface.Line(TX(ray.Origin.X), TY(ray.Origin.Z), 
                TX(intersectionpoint.X), 
                TY(intersectionpoint.Z), 0xFFFF00); //primary rays are yellow
        }

        //for when there isn't a collision
        public void RenderRay(Ray ray)
        {
            Vector3 intersectionpoint = ray.Origin + (500 * ray.Dir);
            surface.Line(TX(ray.Origin.X), TY(ray.Origin.Z),
                TX(intersectionpoint.X),
                TY(intersectionpoint.Z), 0xFFFF00); //primary rays are yellow
        }

        public void RenderShadowRay(Ray ray, Intersection intersection)
        {
            Vector3 intersectionpoint = ray.Origin + (intersection.Distance * ray.Dir);
            surface.Line(TX(ray.Origin.X), TY(ray.Origin.Z),
                TX(intersectionpoint.X),
                TY(intersectionpoint.Z), 0xFF0000); //shadowrays are red
        }

        public void RenderSecondaryRay(Ray ray, Intersection intersection)
        {
            Vector3 intersectionpoint = ray.Origin + (intersection.Distance * ray.Dir);
            surface.Line(TX(ray.Origin.X), TY(ray.Origin.Z),
                TX(intersectionpoint.X),
                TY(intersectionpoint.Z), 0x00FF00); //secondary rays are green
        }

        public void RenderScreenPlane(Vector3 lu, Vector3 ru)
        {
            surface.Line(TX(lu.X), TY(lu.Z), TX(ru.X), TY(ru.Z), 0xFFFFFF);
        }

        public void RenderCamera()
        {
            surface.Plot(TX(camera.pos.X), TY(camera.pos.Z), 0xFFFFFF);
        }

        public void RenderPlane(float distance, Vector3 color)
        {
            surface.Line(TX(-2), TY(camera.pos.Z + distance), TX(2), TY(camera.pos.Z + distance), 0xFFFFFF);
        }

        //translations
        public int TX(float x)
        {
            x += ((planewidthx/2) * zoom);  //offset //centerX = 0 dus niet -0 want dat is wasted psace
            x *= (512 / planewidthx);   //scale (512 = screen.width(debugscreen))
            x = x / zoom;     //zoom extra
            x += 512;
            return (int)x;
        }

        public int TY(float y)
        {
            y += ((planewidthy/2) * zoom);            //offset, normaal - centerY maar die is 0 bij ons
            y *= (surface.height / planewidthy);            //scale
            //zoom (higher zoom = zooming out)
            y /= zoom;
            //reverse the y
            y = (surface.height - y);
            return (int)y;
        }

        //createColor (with bitshifting)
        public int createColor(Vector3 v)
        {
            int x = (int)(v.X * 255);
            int y = (int)(v.Y * 255);
            int z = (int)(v.Z * 255);
            return (x << 16) + (y << 8) + (z);
        }
    }
}
