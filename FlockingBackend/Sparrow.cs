using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    ///<summary>
    ///This class is used to represent a single sparrow. 
    ///This class is just a starting point. Complete the TODO sections
    ///</summary>
    public class Sparrow : Bird
    {
        //TODO: Add the constructor, properties and fields as specified in the instructions document.
        /// <summary>
        /// This constructor method uses the base class to initialize its fields.
        /// </summary>
        /// <returns></returns>
        public Sparrow() : base() { }

        /// <summary>
        /// Parameterized constructor takes 4 inputs: positionVx, positionVy, velocityVx, velocityVy.
        /// Used for testing. Assigns the parameters as the values for Position and Velocity
        /// <param name="positionX"> X value of position of bird </param>
        /// <param name="positionY"> Y value of position of bird </param>
        /// <param name="velocityX"> X value of velocity of bird </param>
        /// <param name="velocityY"> Y value of velocity of bird </param>
        /// </summary>
        public Sparrow(float positionVx, float positionVy, float velocityVx, float velocityVy) : base(positionVx, positionVy, velocityVx, velocityVy) { }

        ///<summary>
        ///This method is an event handler to calculate and set amountToSteer vector using the flocking algorithm rules
        ///</summary>
        ///<param name="sparrows">List of sparrows</param>
        public override void CalculateBehaviour(List<Sparrow> sparrows)
        {
            //TODO: Set the amountToSteer vector with the vectors returned by 
            //Cohesion, Alignment, Avoidance methods
            this.amountToSteer = this.Alignment(sparrows);
            this.amountToSteer += this.Cohesion(sparrows);
            this.amountToSteer += this.Avoidance(sparrows);
        }

        ///<summary>
        ///This method is an event handler to calculate and update amountToSteer vector with the amount to steer to flee a chasing raven
        /// The CalculateRavenAvoidance focuses on fleeing over other behaviours
        ///</summary>
        ///<param name="raven">A Raven object</param>
        public void CalculateRavenAvoidance(Raven raven)
        {
            Vector2 fleeRaven = this.FleeRaven(raven);
            if (fleeRaven.Vx != 0 || fleeRaven.Vy != 0)
            {
                amountToSteer = fleeRaven;
            }

        }


        /// <summary>
        /// This helper method  calculates the vector to add to amountToSteer. It calculates
        /// the vector value to align this current's sparrow's velocity to its surrounding's sparrows
        /// velocity based on the neighbour radius spceified in <c>World</c> class.
        /// </summary>
        /// <param name="sparrows">List of sparrows in the world.</param>
        /// <returns>Normalized Vector used to align a sparrow </returns>
        public Vector2 Alignment(List<Sparrow> sparrows)
        {
            Vector2 sumVel = new Vector2(0, 0);
            // For each sparrow in World's NeighbourRadius that is not ourselves, add it in the 
            // avgVel variable.
            float sqNeighbourRadius = (float)Math.Pow(World.NeighbourRadius, 2);
            int count = 0;
            foreach (Sparrow sparrow in sparrows)
            {
                float sqDistance = Vector2.DistanceSquared(this.Position, sparrow.Position);
                // Make the radius inclusive.
                if (sqDistance <= sqNeighbourRadius && sparrow != this)
                {
                    sumVel += sparrow.Velocity;
                    count++;
                }
            }
            // If no sparrows are found in the neighbour radius area, then return a 0 vector to not affect
            // amountToSteer property. Otherwise normalize the sum of velocities, and multiply by the max speed.
            // Then compute the difference between the average velocity with max speed as magnitude and this
            // current velocity, and finally, normalize the result.
            if (count != 0 || !(Vector2.IsZeroVector(sumVel)))
            {
                // Normalize sum of velocities.
                Vector2 result = Vector2.SafeNormalize(sumVel);
                // Multiply result by MaxSpeed
                result = result * World.MaxSpeed;
                // Compute difference between avg velocity and current velocity.
                result = result - this.Velocity;
                // Re-Normalize and return
                return Vector2.SafeNormalize(result);
            }
            else
            {
                // return a 0 vector.
                return new Vector2(0, 0);
            }
        }

        /// <summary>
        /// This function computes the vector to align a sparrow towards the average
        /// position of its surrounding based on the neighbour radius specified in <c>World</c> class.
        /// </summary>
        /// <param name="sparrows">List of sparrows in the world.</param>
        /// <returns>Normalized Vector used to point a sparrow toward the center of the flock</returns>
        public Vector2 Cohesion(List<Sparrow> sparrows)
        {
            Vector2 sumPosition = new Vector2(0, 0);
            // Sum each sparrow's position to the sumPosition vector.
            float sqNeighbourRadius = (float)Math.Pow(World.NeighbourRadius, 2);
            int count = 0;
            foreach (Sparrow sparrow in sparrows)
            {
                float sqDistance = Vector2.DistanceSquared(this.Position, sparrow.Position);
                // Make the radius inclusive.
                if (sqDistance <= sqNeighbourRadius && sparrow != this)
                {
                    sumPosition += sparrow.Position;
                    count++;
                }
            }
            // If no sparrows are found in the neighbour radius area, then return a 0 vector to not affect
            // amountToSteer property. Otherwise compute average position, and subtract current position from avg.
            // Then normalize result vector and multiply by MaxSpeed. Substract the current velocity from the result 
            // re-normalize again.
            if (count != 0 || !(Vector2.IsZeroVector(sumPosition)))
            {
                // Compute avg position vector.
                Vector2 result = sumPosition / count;
                // Compute displacementVector --> receive vector from your position to the avg position
                result = result - this.Position;
                // Normalize vector
                result = Vector2.SafeNormalize(result);
                // Multiply by max speed
                result = result * World.MaxSpeed;
                // Compute sparrow's velocity after displacement
                result = result - this.Velocity;
                // Re-Normalize and return
                return Vector2.SafeNormalize(result);
            }
            else
            {
                // return a 0 vector.
                return new Vector2(0, 0);
            }
        }

        /// <summary>
        /// This function computes the vector value to avoid a sparrow to collide with another one 
        /// based on the avoidance Radius specified in the <c>World</c> class.
        /// </summary>
        /// <param name="sparrows">List of sparrows in the world.</param>
        /// <returns>Normalized Vector used to point a sparrow away from colliding with another sparrow</returns>
        public Vector2 Avoidance(List<Sparrow> sparrows)
        {
            Vector2 sumPosition = new Vector2(0, 0);
            // Sum each sparrow's position to the sumPosition vector.
            float sqAvoidanceRadius = (float)Math.Pow(World.AvoidanceRadius, 2);
            int count = 0;
            foreach (Sparrow sparrow in sparrows)
            {
                float sqDistance = Vector2.DistanceSquared(this.Position, sparrow.Position);
                // Make the radius inclusive.
                if (sqDistance <= sqAvoidanceRadius && sqDistance != 0.0f && sparrow != this)
                {
                    // Substract current position with sparrow's position.
                    Vector2 v = this.Position - sparrow.Position;
                    // Divide difference by distance.
                    v = v / sqDistance;
                    sumPosition += v;
                    count++;
                }
            }
            if (count != 0 && !(Vector2.IsZeroVector(sumPosition)))
            {
                // Compute avg difference vector.
                Vector2 result = sumPosition / count;
                // // Normalize Vector
                // result = Vector2.SafeNormalize(result);
                // // Multiply by MaxSpeed
                // result = result * World.MaxSpeed;
                // // Compute result - this.Velocity
                // result = result - this.Velocity;
                // Re-Normalize and return
                return Vector2.SafeNormalize(result);
            }
            else
            {
                // return a 0 vector.
                return new Vector2(0, 0);
            }
        }

        /// <summary>
        /// This function computes the vector value to flee from a Raven entity. Similar to avoidance function
        /// it will assess the raven in its surrounding and return the vector that will steer the velocity to avoid
        /// the raven entity.
        /// </summary>
        /// <param name="raven">Raven entity in the world</param>
        /// <returns>Normalized Vector used to point a sparrow away from colliding with another sparrow</returns>
        public Vector2 FleeRaven(Raven raven)
        {
            float squaredFleeRadius = (float)Math.Pow(World.FleeRadius, 2);
            float sqDistance = Vector2.DistanceSquared(this.Position, raven.Position);
            if (sqDistance <= squaredFleeRadius && sqDistance != 0.0f)
            {
                // Compute difference of position between this sparrow and the raven.
                Vector2 result = this.Position - raven.Position;
                // Divide the difference by the distance
                result = result / (float)Math.Sqrt(sqDistance);
                // Normalize the difference.
                result = Vector2.SafeNormalize(result);
                // Multiply by the maximum speed.
                result = result * World.MaxSpeed;
                // Re-Normalize and return
                return Vector2.SafeNormalize(result);
            }
            else if (sqDistance == 0.0f)
            {
                // If the raven is exactly on the same position as the sparrow
                // make the sparrow speed up in the same velocity and direction to escape the raven
                return Vector2.SafeNormalize(this.Velocity);
            }
            else
            {
                // return a 0 vector.
                return new Vector2(0, 0);

            }
        }
    }
}