using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    class Scene
    {
        public List<Primitive> primitives;
        public List<Light> lights;
        Debug debug;

        //initialize here; create the primitives/lights
        public Scene(Debug debug)
        {
            this.debug = debug;

            primitives = new List<Primitive>();
            lights = new List<Light>();

            Material d = new DiffuseMaterial();
            Material m = new Mirror();

            //create plane
            //Plane p = new Plane(2.0f, new Vector3(0, 1, 0).Normalized(), new Vector3(.55f, 1, .44f), d);
            //primitives.Add(p);

            //create spheres
            Sphere s1 = new Sphere(new Vector3(-3, 0, 4), 2.0f, new Vector3(0.25f, 1, 1), d);
            primitives.Add(s1); //voeg de primitive toe aan de lijst

            Sphere s2 = new Sphere(new Vector3(0, 0, 5), 2.0f, new Vector3(0.48f, 0.14f, 0.15f), d);
            primitives.Add(s2);

            Sphere s3 = new Sphere(new Vector3(3, 0, 8), 2.0f, new Vector3(1, 1, 1), m);
            primitives.Add(s3);

            //add some lights
            Light light = new Light(new Vector3(30, 30, 30), new Vector3(4, 5, 2));
            lights.Add(light);

            Light light2 = new Light(new Vector3(10, 10, 10), new Vector3(6, 6, 0));
            lights.Add(light2);

            //fancy green light
            Light greenLight = new Light(new Vector3(0, 30, 0), new Vector3(0, 8, 4));
            lights.Add(greenLight);
        }
        
        public Intersection intersect(Ray ray)
        {
            Intersection result = null;
            Intersection i;
            //loop through primitives list for each ray, detect earliest collision
            foreach (Primitive p in primitives)
            {
                i = p.intersect(ray);
                if (i != null)
                {
                    //filter out the smallest intersection, 
                    if (result == null || result.Distance > i.Distance) //if the result distance is bigger, make it the smaller one
                    {
                        result = i;
                    }
                }
            }

            return result;
        }

        public Vector3 applyLights(Ray r, Intersection i, Vector3 color, bool isDebugRay)
        {
            Vector3 returnColor = color;
            Vector3 intersectPoint = r.Origin + (r.Dir * i.Distance);
            Vector3 surfaceNormal = i.normal;

            foreach (Light light in lights)
            {
                //we willen vd light naar de intersectionpoint toe gaan
                Vector3 lightDir = (light.pos - intersectPoint).Normalized();

                //check if the light source is behind the primitive
                if (Vector3.Dot(surfaceNormal, lightDir) < 0)
                {
                    //do not do anything if the light is behind primitive
                }
                else
                {
                    Intersection result = null; //null on start, if it finds an intersection, it's not null anymore
                    Intersection intersection;

                    Ray shadowRay;
                    shadowRay = new Ray();
                    shadowRay.Dir = lightDir;
                    shadowRay.Origin = intersectPoint + (float.Epsilon * shadowRay.Dir);
                    //offset the ray origin by epsilon times the ray direction

                    foreach (Primitive p in primitives)
                    {
                        intersection = p.intersect(shadowRay);
                        if (intersection != null && (intersection.Distance < (light.pos - intersectPoint).Length - (2 * float.Epsilon))
                            && intersection.Distance > 0) //restriction on ray: 0 < distance < Plight - I - (2 * float.epsilon)
                        {
                            //if we found a valid intersection, it means we shouldn't do anything with the light
                            result = intersection;

                            //debug.RenderShadowRay(shadowRay, result);//render shadowray if it's debug ray <!-- not working -->
                            break; //break out since there is an intersection
                        }
                    }

                    //if no primitives in the way have been found, apply the light multiplication to the color
                    if (result == null)
                    {
                        float lightDistanceTravelled = (light.pos - intersectPoint).Length;
                        returnColor *= (new Vector3(1, 1, 1) +(light.intensity / (lightDistanceTravelled * lightDistanceTravelled)));
                    }
                }
            }

            //clamp values to max 1,1,1
            if (returnColor.X > 1)
            {
                returnColor.X = 1;
            }
            if (returnColor.Y > 1)
            {
                returnColor.Y = 1;
            }
            if (returnColor.Z > 1)
            {
                returnColor.Z = 1;
            }
            return returnColor;
        }
    }
}
