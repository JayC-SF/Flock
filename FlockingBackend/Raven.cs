using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    ///<summary>
    /// Raven class encapsulates the fields and method of a Raven object
    ///</summary>
    public class Raven : Bird
    {
        /// <summary>
        /// Default Constructor to initialize Raven object
        /// </summary>
        public Raven() : base()
        {
            // nothing to add!
        }

        /// <summary>
        /// Parameterized Constructor to unit test Raven object
        /// </summary>
        public Raven(float positionVx, float positionVy, float velocityVx, float velocityVy) : base(positionVx, positionVy, velocityVx, velocityVy)
        {
            //nothing to add!
        }

        ///<summary>
        ///This method is an event handler to calculate and set amountToSteer vector
        ///</summary>
        ///<param name="sparrows">List of sparrows</param>
        public override void CalculateBehaviour(List<Sparrow> sparrows)
        {
            this.amountToSteer = ChaseSparrow(sparrows);
        }

        ///<summary>
        /// ChaseSparrow() returns the Vector2 difference between the Raven's position and the closest Sparrow to it
        ///</summary>
        ///<param name="sparrows">List of sparrows</param>
        ///<returns> Vector2 of difference between the Raven's position and the closest Sparrow </returns>
        public Vector2 ChaseSparrow(List<Sparrow> sparrows)
        {
            Sparrow closestSparrow = null;
            float squaredChasingRadius = (float)Math.Pow(World.ChasingRadius, 2);
            float closestSqDistance = squaredChasingRadius;
            foreach (Sparrow sparrowObj in sparrows)
            {
                float squaredDistance = Vector2.DistanceSquared(this.Position, sparrowObj.Position);
                if (squaredDistance < closestSqDistance)
                {
                    closestSparrow = sparrowObj;
                    closestSqDistance = squaredDistance;
                }
            }

            if (closestSparrow == null)
            {
                return new Vector2(0, 0);
            }
            return Vector2.SafeNormalize(closestSparrow.Position - this.Position);
        }

        ///<summary>
        /// Move() overrides the abstract Move() from Bird. Normalizes the Velocity and speeds it up to the Max Speed
        ///</summary>
        public override void Move()
        {
            if (Vector2.Magnitude(this.Velocity) > World.MaxSpeed)
            {
                this.Velocity = Vector2.SafeNormalize(this.Velocity) * World.MaxSpeed;
            }
            base.Move();
        }
    }
}