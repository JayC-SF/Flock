using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlockingBackend;
using System.Collections.Generic;

namespace FlockingUnitTests
{
    /// <summary>
    /// RavenTest tests all the fields and methods of a Raven object
    /// </summary>
    [TestClass]
    public class RavenTest
    {
        /// <summary>
        /// This method checks if initialized Raven object isn't null
        /// </summary>
        [TestMethod]
        public void InitializeRavenConstructorTest_PositionAndVelocity_CheckIfRavenIsNotNull()
        {
            //ARRANGE & ACT
            Raven ravenTest = new Raven(1, 2, 3, 4);
            Raven ravenTestNoParams = new Raven();

            //ASSERT
            Assert.IsNotNull(ravenTest);
            Assert.IsNotNull(ravenTestNoParams);
        }

        /// <summary>
        /// This method checks if the Raven's Velocity and Position are initialized properly and are correct
        /// </summary>
        [TestMethod]
        public void RavenPropertiesTestOnInitialize_PositionAndVelocity_CheckIfPropertiesAreEqual()
        {
            Raven ravenTest = new Raven(2, -3, 5, 10);

            //Velocity
            Vector2 currentVelocity = ravenTest.Velocity;
            Vector2 expectedVelocity = new Vector2(5, 10);
            Assert.AreEqual(currentVelocity, expectedVelocity);

            //Position
            Vector2 currentPosition = ravenTest.Position;
            Vector2 expectedPosition = new Vector2(2, -3);
            Assert.AreEqual(currentPosition, expectedPosition);

        }

        /// <summary>
        /// This method checks if Rotation of Raven is correct
        /// </summary>
        /// <param name="Vy">Y Property of Vector</param>
        /// <param name="Vx">X Property Of Vector</param>
        /// <param name="expectedRotation">rotation float</param>
        [DataTestMethod]
        [DataRow(1, 2, 0.463f)]
        [DataRow(3, 4, 0.644f)]
        [DataRow(-1, 1, -0.785f)]
        public void RavenRotationTest_XAndYProperties_ReturnsFloatAtan2(float Vy, float Vx, float expectedRotation)
        {
            //ARRANGE
            Raven ravenTest = new Raven(0, 0, Vx, Vy);

            //ACT
            float currentRotation = ravenTest.Rotation;

            //ASSERT
            Assert.AreEqual(currentRotation, expectedRotation, 0.01);
        }

        /// <summary>
        /// This method checks if Raven's Move() method modifies its Velocity and Position from the original
        /// </summary>
        [TestMethod]
        public void RavenMoveTest_PositionAndVelocity_CompareInitialAndFinalVelocityAndPosition()
        {
            //ARRANGE
            Raven ravenTest = new Raven(2, 4, 5, 10);

            Vector2 initialVelocity = ravenTest.Velocity;
            Vector2 initialPosition = ravenTest.Position;

            //ACT
            ravenTest.Move();

            Vector2 finalVelocity = ravenTest.Velocity;
            Vector2 finalPosition = ravenTest.Position;

            //ASSERT
            Assert.AreNotEqual(initialVelocity.Vx, finalVelocity.Vx);
            Assert.AreNotEqual(initialVelocity.Vy, finalVelocity.Vy);
            Assert.AreNotEqual(initialPosition.Vx, finalPosition.Vx);
            Assert.AreNotEqual(initialPosition.Vy, finalPosition.Vy);
        }

        /// <summary>
        /// This method calculates if the Velocity and Position of a Raven have the correct values after moving
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="vX"></param>
        /// <param name="vY"></param>
        /// <param name="exppX"></param>
        /// <param name="exppY"></param>
        /// <param name="expvX"></param>
        /// <param name="expvY"></param>
        [DataTestMethod]
        [DataRow(0, 0, 1, 1, 1f, 1f, 1f, 1f)]
        [DataRow(5, 3, 3, 5, 7.058f, 6.430f, 2.058f, 3.430f)]
        public void RavenMoveTest_PositionAndVelocity_AssertEqualValues(float pX, float pY, float vX, float vY, float exppX, float exppY, float expvX, float expvY)
        {
            //ARRANGE
            Raven ravenTest = new Raven(pX, pY, vX, vY);

            //ACT
            ravenTest.Move();

            //ASSERT
            Assert.AreEqual(ravenTest.Velocity.Vx, expvX, 0.01);
            Assert.AreEqual(ravenTest.Velocity.Vy, expvY, 0.01);
            Assert.AreEqual(ravenTest.Position.Vx, exppX, 0.01);
            Assert.AreEqual(ravenTest.Position.Vy, exppY, 0.01);
        }

        /// <summary>
        /// This method checks if ChaseSparrow() returns the correct values
        /// </summary>
        /// <param name="ravenposX"></param>
        /// <param name="ravenposY"></param>
        /// <param name="sparrow1posX"></param>
        /// <param name="sparrow1posY"></param>
        /// <param name="sparrow2posX"></param>
        /// <param name="sparrow2posY"></param>
        /// <param name="sparrow3posX"></param>
        /// <param name="sparrow3posY"></param>
        /// <param name="expX"></param>
        /// <param name="expY"></param>
        [DataTestMethod]
        [DataRow(0, 0, 1, 1, 2, 2, 3, 3, 0.707f, 0.707f)]
        [DataRow(0, 0, 1, 1, 3, 3, 2, 2, 0.707f, 0.707f)]
        [DataRow(2, 3, 1, 1, 4, 5, 10, 12, -0.447f, -0.894f)]
        [DataRow(0, 0, -3, 4, 50, 50, -1, -2, -0.447f, -0.894f)]
        [DataRow(0, 0, 50, 50, 1, 2, 50, 50, 0.447f, 0.894f)]
        [DataRow(1, 1, 50, 50, 100, 100, 123, 321, 0, 0)]
        [DataRow(0, 0, 0, 0, 0, 0, 30, 40, 0, 0)]
        [DataRow(0, 0, 1, 2, -1, -2, 50, 50, 0.447f, 0.894f)]
        public void RavenChaseSparrowTest_ListOf3Sparrows_ExpectedChaseSparrowSteeringVectorValue(float ravenposX, float ravenposY, float sparrow1posX, float sparrow1posY, float sparrow2posX, float sparrow2posY, float sparrow3posX, float sparrow3posY, float expX, float expY) //need to change ChaseSparrow() method in Raven.cs as public in order to test
        {
            //ARRANGE
            Raven ravenTest = new Raven(ravenposX, ravenposY, 1, 1);
            List<Sparrow> sparrowsTest = new List<Sparrow>();
            sparrowsTest.Add(new Sparrow(sparrow1posX, sparrow1posY, 0, 0));
            sparrowsTest.Add(new Sparrow(sparrow2posX, sparrow2posY, 0, 0));
            sparrowsTest.Add(new Sparrow(sparrow3posX, sparrow3posY, 0, 0));

            //ACT
            Vector2 closest = ravenTest.ChaseSparrow(sparrowsTest);

            //ASSERT
            Assert.AreEqual(closest.Vx, expX, 0.01);
            Assert.AreEqual(closest.Vy, expY, 0.01);

        }

        /// <summary>
        /// This method checks if ChaseSparrow() returns a Vector of 0 in case Sparrow List is empty
        /// </summary>
        [TestMethod]
        public void RavenChaseSparrowTest_EmptySparrowsList_ReturnVectorOf0()
        {
            //ARRANGE
            Raven ravenTest = new Raven(1, 2, 3, 4);
            List<Sparrow> emptySparrows = new List<Sparrow>();

            //ACT
            Vector2 empty = ravenTest.ChaseSparrow(emptySparrows);

            //ASSERT
            Assert.IsNotNull(emptySparrows);
            Assert.AreEqual(emptySparrows.Count, 0);

            Assert.AreEqual(empty.Vx, 0);
            Assert.AreEqual(empty.Vy, 0);
        }
    }
}