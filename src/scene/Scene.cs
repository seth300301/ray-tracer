using System;
using System.Collections.Generic;

namespace RayTracer
{
    /// <summary>
    /// Class to represent a ray traced scene, including the objects,
    /// light sources, and associated rendering logic.
    /// </summary>
    public class Scene
    {
        private SceneOptions options;
        private ISet<SceneEntity> entities;
        private ISet<PointLight> lights;

        /// <summary>
        /// Construct a new scene with provided options.
        /// </summary>
        /// <param name="options">Options data</param>
        public Scene(SceneOptions options = new SceneOptions())
        {
            this.options = options;
            this.entities = new HashSet<SceneEntity>();
            this.lights = new HashSet<PointLight>();
        }

        /// <summary>
        /// Add an entity to the scene that should be rendered.
        /// </summary>
        /// <param name="entity">Entity object</param>
        public void AddEntity(SceneEntity entity)
        {
            this.entities.Add(entity);
        }

        /// <summary>
        /// Add a point light to the scene that should be computed.
        /// </summary>
        /// <param name="light">Light structure</param>
        public void AddPointLight(PointLight light)
        {
            this.lights.Add(light);
        }


        /// <summary>
        /// Finds the closest intersecting entity of a ray, if any.
        /// </summary>
        /// <param name="ray">A given ray</param>
        public SceneEntity EntityInt(Ray ray) {
            double closest = Double.MaxValue;
            SceneEntity entityInt = null;

            foreach (SceneEntity entity in this.entities) {
                RayHit hit = entity.Intersect(ray);

                // if the ray hits/intersects an entity
                if (hit != null) {
                    // if the entity is the closest one to the origin
                    if ((hit.Position - ray.Origin).Length() < closest) {
                        closest = (hit.Position - ray.Origin).Length();
                        entityInt = entity;
                    }
                }
            }
            return entityInt;
        }

        /// <summary>
        /// Figures out if a pixel is in shadow or not.
        /// </summary>
        /// <param name="light">Light structure</param>
        /// <param name="hit">A rayhit</param>
        public bool Shadow(PointLight light, RayHit hit) {
            Vector3 shadowDirection = (light.Position - hit.Position).Normalized();
            Ray shadow = new Ray((hit.Position + (0.0000001 * shadowDirection)), shadowDirection);
            double shadowClosest = (hit.Position - light.Position).Length();
            bool shadowed = false;

            foreach (SceneEntity entity in this.entities) {
                RayHit shadowHit = entity.Intersect(shadow);
                // if the shadow ray hits/intersects an entity
                if (shadowHit != null) {
                    // if an entity is the closest one to the shadow ray
                    if ((hit.Position - shadowHit.Position).Length() < shadowClosest) {
                        shadowClosest = (hit.Position - shadowHit.Position).Length();
                        shadowed = true;
                    }
                }
            }
            return shadowed;
        }

        /// <summary>
        /// Calculates the direction of a reflection.
        /// </summary>
        /// <param name="incident">the incident ray</param>
        /// <param name="normal">normal of the entity</param>
        public Vector3 Reflect(Vector3 incident, Vector3 normal) 
        { 
            return incident - (2 * incident.Dot(normal) * normal); 
        } 

        /// <summary>
        /// Calculates the direction of a refraction.
        /// </summary>
        /// <param name="incident">the incident ray</param>
        /// <param name="normal">normal of the entity</param>
        /// <param name="IOR">the index of refraction</param>
        public Vector3 Refract(Vector3 incident, Vector3 normal, double IOR)
        {
            double cosi = Math.Clamp(incident.Dot(normal), -1.0, 1.0);
            double etai = 1, etat = IOR;
            Vector3 n = normal;
            if (cosi < 0.0) {
                cosi = -cosi;
            }
            else {
                double temp = etat;
                etat = etai;
                etai = temp;
                n = -normal;
            }
            double eta = etai / etat;
            double k = 1 - (eta * eta * (1 - (cosi * cosi)));
            
            return (eta * incident) + (n * ((eta * cosi) - Math.Sqrt(k)));
        }

        /// <summary>
        /// Calculates kr using Fresnel equations.
        /// </summary>
        /// <param name="incident">the incident ray</param>
        /// <param name="normal">normal of the entity</param>
        /// <param name="IOR">the index of refraction</param>
        public double Fresnel(Vector3 incident, Vector3 normal, double IOR)
        {
            double cosi = Math.Clamp(incident.Dot(normal), -1.0, 1.0);
            double etai = 1, etat = IOR;
            Vector3 n = normal;
            if (cosi > 0) {
                double temp = etat;
                etat = etai;
                etai = temp;
                n = -normal;
            }

            double sint = (etai / etat) * Math.Sqrt(Math.Max(0, 1 - (cosi * cosi)));
            double kr;
            if (sint >= 1) { kr = 1; }
            else {
                double cost = Math.Sqrt(Math.Max(0, 1 - (sint * sint))); 
                cosi = Math.Abs(cosi); 
                double Rs = ((etat * cosi) - (etai * cost)) / ((etat * cosi) + (etai * cost)); 
                double Rp = ((etai * cosi) - (etat * cost)) / ((etai * cosi) + (etat * cost)); 
                kr = (Rs * Rs + Rp * Rp) / 2; 
            }
            return kr;
        }

        /// <summary>
        /// Return the color of a pixel.
        /// </summary>
        /// <param name="ray">incident ray</param>
        /// <param name="depth">current depth for reflections and refractions</param>
        public Color Trace(Ray ray, int depth) {
            int MAX_DEPTH = 3;
            Color black = new Color(0.0, 0.0, 0.0);
            Color white = new Color(255.0, 255.0, 255.0);
            Color color = black;

            // the closest intersecting entity of the ray, if non then it is null
            SceneEntity entityInt = EntityInt(ray);
            if ((depth > MAX_DEPTH) || (entityInt == null)) { return black; }

            RayHit hit = entityInt.Intersect(ray);

            if ((entityInt.Material.Type == Material.MaterialType.Reflective) && (depth <= MAX_DEPTH)) { // material is reflective type
                Vector3 direction = Reflect(ray.Direction, hit.Normal).Normalized();
                Ray reflection = new Ray(hit.Position + (0.0000001 * ray.Direction), direction);
                color = Trace(reflection, depth + 1);
            }

            else if ((entityInt.Material.Type == Material.MaterialType.Refractive) && (depth <= MAX_DEPTH)) { // material is refractive type
                Color refractColor = black;
                double kr = Fresnel(ray.Direction, hit.Normal, entityInt.Material.RefractiveIndex);

                // refraction part
                if (kr < 1.0) {
                    Vector3 refractDir = Refract(ray.Direction, hit.Normal, entityInt.Material.RefractiveIndex).Normalized();
                    Ray refraction = new Ray(hit.Position + (0.0000001 * ray.Direction), refractDir);
                    refractColor = Trace(refraction, depth + 1);
                }

                // reflection part
                Vector3 reflectDir = Reflect(ray.Direction, hit.Normal).Normalized();
                Ray reflection = new Ray(hit.Position + (0.0000001 * ray.Direction), reflectDir);
                Color reflectColor = Trace(reflection, depth + 1);

                // mixes the colors of refraction and reflection using the fresnel equation
                color = (reflectColor * kr) + (refractColor * (1 - kr));
                color = color.Clamp();
            }

            else if (entityInt.Material.Type == Material.MaterialType.Glossy) { // material is glossy type
                // best looking parameters by trial and error
                double n = 7;
                double ks = 0.2;
                double kd = 1 - ks;
                
                Color diffuse = black;
                Color specular = black;

                // if the ray from the origin has an intersecting entity
                foreach (PointLight light in this.lights) {
                    if (entityInt != null) {
                        
                        // if the pixel is in a shadow
                        bool shadowed = Shadow(light, hit);
                        // if the shadow ray doesn't have an intersecting entity
                        if (shadowed == false) {
                            // diffuse part
                            Vector3 L = (light.Position - hit.Position).Normalized();
                            double normalDotL = hit.Normal.Dot(L);
                            Color currentColor = entityInt.Material.Color * light.Color;
                            diffuse = diffuse + (currentColor * normalDotL);

                            // reflection part
                            Vector3 reflectDir = Reflect(L, hit.Normal).Normalized();
                            double reflectDotDir = reflectDir.Dot(-ray.Direction);
                            for (int i = 0; i < n; i++) {
                                reflectDotDir = reflectDotDir * reflectDotDir;
                            }
                            specular = specular + (light.Color * reflectDotDir);

                            // keep all RGB values between 0.0 and 1.0
                            diffuse = diffuse.Clamp();
                            specular = specular.Clamp();
                        }
                    }
                }
                // mixes colors of the object and some reflection
                color =  (diffuse * kd) + (specular * ks);
            }

            else if (entityInt.Material.Type == Material.MaterialType.Diffuse) { // material is diffuse type
                // if the ray from the origin has an intersecting entity
                foreach (PointLight light in this.lights) {
                    if (entityInt != null) {
                        
                        // if the pixel is in a shadow
                        bool shadowed = Shadow(light, hit);
                        // if the shadow ray doesn't have an intersecting entity
                        if (shadowed == false) {
                            Vector3 L = (light.Position - hit.Position).Normalized();
                            double normalDotL = hit.Normal.Dot(L);
                            Color currentColor = entityInt.Material.Color * light.Color;
                            color = color + (currentColor * normalDotL);

                            // keep all RGB values between 0.0 and 1.0
                            color = color.Clamp();
                        }
                    }
                }
            }
            return color;
        }

        /// <summary>
        /// Render the scene to an output image. This is where the bulk
        /// of your ray tracing logic should go... though you may wish to
        /// break it down into multiple functions as it gets more complex!
        /// </summary>
        /// <param name="outputImage">Image to store render output</param>
        public void Render(Image outputImage)
        {
            //Vector3 origin = new Vector3(0, 0, 0);
            double aspectRatio = (outputImage.Width / outputImage.Height);

            // anti-aliasing multiplier
            double AA = options.AAMultiplier;

            // camera orientation variables
            Vector3 origin = options.CameraPosition;
            Vector3 axis = (options.CameraAxis).Normalized();
            double degrees = options.CameraAngle;

            Vector3 z_axis = new Vector3(0, 0, 1);
            double radian = degrees * Math.PI / 180;
            Vector3 tmp = (new Vector3(0, 1, 0)).Normalized();

            // rotation matrix for 3D vectors using a left-handed coordinate system
            Vector3 rotateRow1 = new Vector3(Math.Cos(radian) + (Math.Pow(axis.X, 2) * (1 - Math.Cos(radian))), 
                                            (axis.X * axis.Y * (1 - Math.Cos(radian))) + (axis.Z * Math.Sin(radian)),
                                            (axis.X * axis.Z * (1 - Math.Cos(radian))) - (axis.Y * Math.Sin(radian)));
            Vector3 rotateRow2 = new Vector3((axis.Y * axis.X * (1 - Math.Cos(radian))) - (axis.Z * Math.Sin(radian)),
                                             Math.Cos(radian) + (Math.Pow(axis.Y, 2) * (1 - Math.Cos(radian))),
                                            (axis.Y * axis.Z * (1 - Math.Cos(radian))) + (axis.X * Math.Sin(radian)));
            Vector3 rotateRow3 = new Vector3((axis.Z * axis.X * (1 - Math.Cos(radian))) + (axis.Y * Math.Sin(radian)), 
                                            (axis.Z * axis.Y * (1 - Math.Cos(radian))) - (axis.X * Math.Sin(radian)),
                                             Math.Cos(radian) + (Math.Pow(axis.Z, 2) * (1 - Math.Cos(radian))));
            // transforming the original direction (0, 0, 1) using the rotation matrix
            Vector3 originDir = (new Vector3(rotateRow1.Dot(z_axis), rotateRow2.Dot(z_axis), rotateRow3.Dot(z_axis))).Normalized();

            // goes through each pixel
            for (int y = 0; y < outputImage.Height; y++) {
                for (int x = 0; x < outputImage.Width; x++) {

                    Color color = new Color(0.0, 0.0, 0.0);
                    double AAInterval = (1 / (2 * AA));

                    // going through the center of each subpixel according to a AA x AA grid within each pixel
                    for (int y_aa = 1; y_aa <= AA; y_aa++) {
                        for (int x_aa = 1; x_aa <= AA; x_aa++) {
                            Vector3 right = tmp.Cross(originDir);
                            Vector3 up = originDir.Cross(right);

                            double x_pos = (((x + (((2 * x_aa) - 1) * AAInterval))/outputImage.Width * 2) - 1)  * Math.Tan((60*Math.PI/180)/2);
                            double y_pos = (1 - (2 * (y + (((2 * y_aa) - 1) * AAInterval))/outputImage.Height)) * (Math.Tan((60*Math.PI/180)/2)) / aspectRatio;

                            Vector3 point = (right * x_pos) + (up * y_pos) + origin + originDir;
                            Vector3 direction = (point - origin).Normalized();
                            Ray ray = new Ray(origin + (0.0000001 * direction), direction);

                            // totals the RGB values of each subpixel
                            color = color + Trace(ray, 0);
                        }
                    }
                    // takes the average of the RGB values
                    color = (color / (AA*AA));
                    color = color.Clamp();
                    outputImage.SetPixel(x, y, color);
                }
            }
        }
    }
}
