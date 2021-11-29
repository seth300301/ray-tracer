using System;

namespace RayTracer
{
    /// <summary>
    /// Class to represent an (infinite) plane in a scene.
    /// </summary>
    public class Sphere : SceneEntity
    {
        private Vector3 center;
        private double radius;
        private Material material;

        /// <summary>
        /// Construct a sphere given its center point and a radius.
        /// </summary>
        /// <param name="center">Center of the sphere</param>
        /// <param name="radius">Radius of the spher</param>
        /// <param name="material">Material assigned to the sphere</param>
        public Sphere(Vector3 center, double radius, Material material)
        {
            this.center = center;
            this.radius = radius;
            this.material = material;
        }

        /// <summary>
        /// Determine if a ray intersects with the sphere, and if so, return hit data.
        /// </summary>
        /// <param name="ray">Ray to check</param>
        /// <returns>Hit data (or null if no intersection)</returns>
        public RayHit Intersect(Ray ray)
        {
            Vector3 L = (this.center - ray.Origin);
            double tc = L.Dot(ray.Direction);
            if (tc < 0.0) { return null; }

            double d2 = L.Dot(L) - tc*tc;
            if (d2 > (this.radius * this.radius)) { return null; }

            double t1c = Math.Sqrt((this.radius * this.radius) - d2);
            double t1 = (tc - t1c);
            double t2 = (tc + t1c);

            Vector3 P1 = ray.Origin + (t1 * ray.Direction);
            Vector3 P2 = ray.Origin + (t2 * ray.Direction);

            Vector3 position;
            // if the P1 is closer to the origin than P2 and the ray's origin is within the sphere, take P1
            if (((P1 - ray.Origin).Length() < (P2 - ray.Origin).Length()) && ((ray.Origin - this.center).Length() >= this.radius)) {
                position = P1;
            }
            // else take P2
            else {
                position = P2;
            }

            Vector3 normal = (position - this.center).Normalized();
            return new RayHit(position, normal, ray.Direction, this.material);
        }

        /// <summary>
        /// The material of the sphere.
        /// </summary>
        public Material Material { get { return this.material; } }
    }

}
