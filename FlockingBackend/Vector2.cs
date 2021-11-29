using System;
namespace FlockingBackend
{
    /// <summary>
    /// This <c>Vector2</c> class represents a 2 dimensional vector object. 
    /// </summary>
    public struct Vector2
    {
        ///<summary>
        /// This getter function represents the X coordinate of a vector 
        /// in a 2D space.
        ///</summary>
        public float Vx
        {
            get;
        }
        ///<summary>
        /// This getter function represents the Y coordinate of a vector 
        /// in a 2D space.
        ///</summary>
        public float Vy
        {
            get;
        }
        /// <summary>
        /// This constructor takes 2 inputs: X properties and Y properties
        /// </summary>
        /// <param name="x">X coordinate value</param>
        /// <param name="y">Y coordinate value</param>
        public Vector2(float x, float y)
        {
            this.Vx = x;
            this.Vy = y;
        }
        /// <summary>
        /// This function operator takes 2 Vectors and adds them together.
        /// The x and y properties are added with each other and are used to 
        /// create a new vector.
        /// <code>return new Vector2(x1 + x2, y1 + y2)</code>
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>Vector2 containing the addition of the fields as properties.</returns>
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.Vx + v2.Vx, v1.Vy + v2.Vy);
        }
        /// <summary>
        /// This function operator takes 2 Vectors and substracts the first one from 
        /// the second one.
        /// The x and y properties of the first vector are subtracted from the second
        ///  vector and are used to create a new vector from the difference.
        /// </summary>
        /// <param name="v1">Minuend Vector</param>
        /// <param name="v2">Subtrahend Vector</param>
        /// <returns>Vector2 containing the substraction of the fields as properties.</returns>
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.Vx - v2.Vx, v1.Vy - v2.Vy);
        }

        /// <summary>
        /// Vector scalar multiplication between a float and a Vector2 class.
        /// This function multiplies the x and y properties by the float value.
        /// </summary>
        /// <param name="val">Float value</param>
        /// <param name="v1">Vector v1</param>
        /// <returns>Vector2 containing the multiplication of v1's fields as properties.</returns>
        public static Vector2 operator *(float val, Vector2 v1)
        {
            return new Vector2(v1.Vx * val, v1.Vy * val);
        }


        /// <summary>
        /// Vector scalar multiplication between a float and a Vector2 class.
        /// This function multiplies the x and y properties by the float value.
        /// </summary>
        /// <param name="val">Float value</param>
        /// <param name="v1">Vector v1</param>
        /// <returns>Vector2 containing the multiplication of v1's fields as properties.</returns>
        public static Vector2 operator *(Vector2 v1, float val)
        {
            return new Vector2(v1.Vx * val, v1.Vy * val);
        }

        /// <summary>
        /// Vector dot product multiplication between a Vector2 and a Vector2 class.
        /// This function multiplies their x and y properties and add their sum to the total.
        /// It follows this formula : x1 * x2 + y1 * y2
        /// </summary>
        /// <param name="v1">Vector v1</param>
        /// <param name="v2">Vector v1</param>
        /// <returns>Float being the dot multiplication of the 2 vectors.</returns>
        public static float operator *(Vector2 v1, Vector2 v2)
        {
            return (v1.Vx * v2.Vx) + (v1.Vy * v2.Vy);
        }

        /// <summary>
        /// Vector scalar division between a float and a Vector2 class.
        /// This function divides the x and y properties by the float value.
        /// </summary>
        /// <param name="v1">Vector2 dividend</param>
        /// <param name="val">Float number divisor</param>
        /// <returns>Vector2 containing the division of v1's fields as properties.</returns>
        public static Vector2 operator /(Vector2 v1, float val)
        {
            return new Vector2(v1.Vx / val, v1.Vy / val);
        }

        /// <summary>
        /// This function returns the distance squared between 2 Vectors.
        /// It follows the following formula.
        /// DistanceSquared = (x1 - x2)^2 + (y1 - y2)^2
        /// </summary>
        /// <param name="v1">Vector2 v1</param>
        /// <param name="v2">Vector2 v2</param>
        /// <returns>Float numerical value of the distance squared between the 2 vectors.</returns>
        public static float DistanceSquared(Vector2 v1, Vector2 v2)
        {
            return (v1.Vx - v2.Vx) * (v1.Vx - v2.Vx) + (v1.Vy - v2.Vy) * (v1.Vy - v2.Vy);
        }

        /// <summary>
        /// This helper function returns the magnitude of a <c>Vector2</c> struct.
        /// </summary>
        /// <param name="v">Vector to be evaluated</param>
        /// <returns>Float value of the magnitude of the vector.</returns>
        public static float Magnitude(Vector2 v)
        {
            float xSquared = v.Vx * v.Vx;
            float ySquared = v.Vy * v.Vy;
            float mag = (float)Math.Sqrt(xSquared + ySquared);
            return mag;
        }

        /// <summary>
        /// This function returns the vector in a normalized form. In other words,
        /// the vector is reduced into a "unit vector" where it keeps it's direction, but it's 
        /// magnitude is reduced into 1 unit.
        /// </summary>
        /// <param name="v">Vector2 v to be used to get the normalized vector.</param>
        /// <returns>Normalized Vector2 struct</returns>
        public static Vector2 Normalize(Vector2 v)
        {
            return v / (Magnitude(v));
        }

        /// <summary>
        /// This function returns the vector in a normalized form. In other words,
        /// the vector is reduced into a "unit vector" where it keeps it's direction, but it's 
        /// magnitude is reduced into 1 unit.
        /// </summary>
        /// <param name="v">Vector2 v to be used to get the normalized vector.</param>
        /// <returns>Normalized Vector2 struct</returns>
        public static Vector2 SafeNormalize(Vector2 v)
        {
            return IsZeroVector(v) ? v : Normalize(v);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool IsZeroVector(Vector2 v)
        {
            return v.Vx == 0.0f && v.Vy == 0.0f;
        }
    }

}