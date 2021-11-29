using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    /// <summary>
    /// The <c>Bird</c> class represents an abstract class of any object that inherits from Bird
    /// </summary>
    public abstract class Bird
    {
        /// <summary>
        /// MinVelocity is a constant value to represent the minimum velocity of a Bird
        /// </summary>
        public const int MinVelocity = -4;

        /// <summary>
        /// MaxVelocity is a constant value to represent the maximum velocity of a Bird
        /// </summary>
        public const int MaxVelocity = 4;

        /// <summary>
        /// Rotation is a float depicting how the Bird will be rotating when it moves
        /// </summary>
        public float Rotation
        {
            get
            {
                return (float)Math.Atan2(this.Velocity.Vy, this.Velocity.Vx);
            }
        }

        /// <summary>
        /// Position Property depicts the position of a Bird object on the Monogame project
        /// </summary>
        public Vector2 Position { get; protected set; }

        /// <summary>
        /// Velocity Property depicts the speed that the Bird object moves on the Monogame project
        /// </summary>
        public Vector2 Velocity { get; protected set; }

        /// <summary>
        /// amountToSteer depicts the Vector2 field that depicts how much is the Velocity of the Bird changing
        /// </summary>
        protected Vector2 amountToSteer;

        /// <summary>
        /// Default constructor takes 0 inputs. Sets up Position, Velocity properties and assigns amountToSteer a Vector2 of 0
        /// </summary>
        public Bird()
        {
            Random rand = new Random();

            this.Position = new Vector2(rand.Next(0, World.Width + 1), rand.Next(0, World.Height + 1));
            this.Velocity = new Vector2(rand.Next(MinVelocity, MaxVelocity + 1), rand.Next(MinVelocity, MaxVelocity + 1));
            this.amountToSteer = new Vector2(0, 0);
        }

        /// <summary>
        /// Parameterized constructor takes 4 inputs: positionVx, positionVy, velocityVx, velocityVy.
        /// Used for testing. Assigns the parameters as the values for Position and Velocity
        /// <param name="positionX"> X value of position of bird </param>
        /// <param name="positionY"> Y value of position of bird </param>
        /// <param name="velocityX"> X value of velocity of bird </param>
        /// <param name="velocityY"> Y value of velocity of bird </param>
        /// </summary>
        public Bird(float positionVx, float positionVy, float velocityVx, float velocityVy)
        {
            this.Position = new Vector2(positionVx, positionVy);
            this.Velocity = new Vector2(velocityVx, velocityVy);
            this.amountToSteer = new Vector2(0, 0);
        }

        /// <summary>
        /// Move() method depicts how the Bird object will move on the Monogame project.
        /// Update Velocity with amountToSteer, then updates Position of Bird. Checks if Bird goes outside of borders of window
        /// </summary>
        public virtual void Move()
        {
            Velocity = Velocity + amountToSteer;
            Position = Position + Velocity;
            AppearOnOppositeSide();
        }

        /// <summary>
        /// CalculateBehaviour() is an abstract method that dictates the behaviour of the Bird object depending on whether it's a Raven or Sparrow
        /// </summary>
        public abstract void CalculateBehaviour(List<Sparrow> sparrows);

        ///<summary>
        /// AppearOnOppositeSide() method is a private helper method to make sparrows reappear on the opposite edge if they go outside the bounds of the screen
        ///</summary>
        private void AppearOnOppositeSide()
        {

            if (this.Position.Vx > World.Width)
            {
                this.Position = new Vector2(0, this.Position.Vy);
            }
            else if (this.Position.Vx < 0)
            {
                this.Position = new Vector2(World.Width, this.Position.Vy);
            }

            if (this.Position.Vy > World.Height)
            {
                this.Position = new Vector2(this.Position.Vx, 0);
            }
            else if (this.Position.Vy < 0)
            {
                this.Position = new Vector2(this.Position.Vx, World.Height);
            }
        }
    }
}