using System;

namespace RayTracer
{
    /// <summary>
    /// Class to represent a triangle in a scene represented by three vertices.
    /// </summary>
    public class Triangle : SceneEntity
    {
        private Vector3 v0, v1, v2;
        private Material material;

        /// <summary>
        /// Construct a triangle object given three vertices.
        /// </summary>
        /// <param name="v0">First vertex position</param>
        /// <param name="v1">Second vertex position</param>
        /// <param name="v2">Third vertex position</param>
        /// <param name="material">Material assigned to the triangle</param>
        public Triangle(Vector3 v0, Vector3 v1, Vector3 v2, Material material)
        {
            this.v0 = v0;
            this.v1 = v1;
            this.v2 = v2;
            this.material = material;
        }

        /// <summary>
        /// Determine if a ray intersects with the triangle, and if so, return hit data.
        /// </summary>
        /// <param name="ray">Ray to check</param>
        /// <returns>Hit data (or null if no intersection)</returns>
        public RayHit Intersect(Ray ray)
        {
            Vector3 v0v1 = v1 - v0; 
            Vector3 v0v2 = v2 - v0; 
            Vector3 normal = v0v1.Cross(v0v2).Normalized();
 
            // if ray and plane are parallel
            if (Math.Abs(normal.Dot(ray.Direction)) < Double.Epsilon) { return null; }

            double d = normal.Dot(v0); 
            double distance = (v0 - ray.Origin).Dot(normal) / ray.Direction.Dot(normal); 

            // if the triangle is in behind the ray
            if (distance < Double.Epsilon) { return null; }

            Vector3 position = ray.Origin + (distance * ray.Direction); 

            // inside-outside test
            Vector3 C; // vector perpendicular to triangle's plane 

            Vector3 edge0 = v1 - v0; 
            Vector3 vp0 = position - v0; 
            C = edge0.Cross(vp0); 
            if (normal.Dot(C) < 0) { return null; } // P is on the right side 

            Vector3 edge1 = v2 - v1; 
            Vector3 vp1 = position - v1; 
            C = edge1.Cross(vp1); 
            if (normal.Dot(C) < 0) { return null; } // P is on the right side 

            Vector3 edge2 = v0 - v2; 
            Vector3 vp2 = position - v2; 
            C = edge2.Cross(vp2); 
            if (normal.Dot(C) < 0) { return null; } // P is on the right side; 

            return new RayHit(position, normal, ray.Direction, this.material);
        }

        /// <summary>
        /// The material of the triangle.
        /// </summary>
        public Material Material { get { return this.material; } }
    }
}
