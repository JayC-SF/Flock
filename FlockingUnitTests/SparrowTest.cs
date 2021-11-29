using System;
using System.Collections.Generic;
using FlockingBackend;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FlockingUnitTests
{
    [TestClass]
    public class SparrowTest
    {
        /// <summary>
        /// This test will test if the sparrow constructor gets initialized properly.
        /// </summary>
        [TestMethod]
        public void TestSparrowConstructor_Empty_FieldsAreProperlyInstatiated()
        {
            // ARRANGE
            Sparrow sparrowTest;
            float resPosX, resPosY, resVelX, resVelY;
            int maxPosX = World.Width,
                maxPosY = World.Height,
                maxVel = Bird.MaxVelocity,
                minVel = Bird.MinVelocity;

            // ACT
            sparrowTest = new Sparrow();
            // store information into variables.
            resPosX = sparrowTest.Position.Vx;
            resPosY = sparrowTest.Position.Vy;
            resVelX = sparrowTest.Velocity.Vx;
            resVelY = sparrowTest.Velocity.Vy;

            // ASSERT
            // Check if the velocity is between Min Velocity and Max Velocity 
            Assert.IsTrue(0 <= resPosX && resPosX <= maxPosX);
            Assert.IsTrue(0 <= resPosY && resPosY <= maxPosY);
            Assert.IsTrue(minVel <= resVelX && resVelX <= maxVel);
            Assert.IsTrue(minVel <= resVelY && resVelY <= maxVel);
        }

        /// <summary>
        /// This class tests whether the sparrow overloaded constructor gets initialzed properly.
        /// </summary>
        /// <param name="posX">Initial X position of the sparrow.</param>
        /// <param name="posY">Initial Y position of the sparrow.</param>
        /// <param name="velX">Initial X position of the sparrow.</param>
        /// <param name="velY">Initial Y position of the sparrow</param>
        [DataTestMethod]
        [DataRow(1, 1, 1, 1)]
        [DataRow(1, 2, 3, 4)]
        [DataRow(1, -2, 3, -4)]
        public void TestSparrowConstructor_PositionAndVelocity_FieldsAreProperlyInstatiated(float posX, float posY, float velX, float velY)
        {
            // ARRANGE
            Sparrow sparrowTest;
            float resPosX, resPosY, resVelX, resVelY;

            // ACT
            sparrowTest = new Sparrow(posX, posY, velX, velY);
            resPosX = sparrowTest.Position.Vx;
            resPosY = sparrowTest.Position.Vy;
            resVelX = sparrowTest.Velocity.Vx;
            resVelY = sparrowTest.Velocity.Vy;

            // ASSERT
            Assert.AreEqual(posX, resPosX);
            Assert.AreEqual(posY, resPosY);
            Assert.AreEqual(velX, resVelX);
            Assert.AreEqual(velY, resVelY);
        }

        /// <summary>
        /// This test will test whether the list of sparrow will result in the expected vector.
        /// The vector to be tested will result in a non zero vector aince the sparrows will be in the 
        /// Neighbour radius.
        /// </summary>
        [TestMethod]
        public void TestAlignment_SparrowListSize3_ReturnsNonZeroAlignmentVector()
        {
            // ARRANGE
            List<Sparrow> sparrows = new List<Sparrow>();
            sparrows.Add(new Sparrow(1, 1, 2, 3));
            sparrows.Add(new Sparrow(2, 2, 2, 3));
            sparrows.Add(new Sparrow(3, 2, 2, 3));
            Sparrow testSparrow = new Sparrow(2, 3, 2, 3);
            float expVx = 0.5547003746032715f;
            float expVy = 0.8320502042770386f;

            // ACT
            Vector2 res = testSparrow.Alignment(sparrows);

            // ASSERT
            Assert.AreEqual(expVx, res.Vx, 0.01);
            Assert.AreEqual(expVy, res.Vy, 0.01);
        }

        /// <summary>
        /// This test will test the alignment of a list of sparrows that are outside of the 
        /// neighbour radious defined in the world.cs file.
        /// </summary>
        [TestMethod]
        public void TestAlignment_SparrowListSize3_ReturnsZeroAlignmentVector()
        {
            // ARRANGE
            List<Sparrow> sparrows = new List<Sparrow>();
            sparrows.Add(new Sparrow(World.NeighbourRadius + 1, World.NeighbourRadius + 1, 2, 3));
            sparrows.Add(new Sparrow(World.NeighbourRadius + 2, World.NeighbourRadius + 2, 2, 3));
            sparrows.Add(new Sparrow(World.NeighbourRadius + 3, World.NeighbourRadius + 2, 2, 3));
            Sparrow testSparrow = new Sparrow(2, 3, 2, 3);
            float expVx = 0;
            float expVy = 0;

            // ACT
            Vector2 res = testSparrow.Alignment(sparrows);

            // ASSERT
            Assert.AreEqual(expVx, res.Vx, 0.01);
            Assert.AreEqual(expVy, res.Vy, 0.01);
        }

        /// <summary>
        /// This test will test the cohesion of the sparrow given a list of sparrows.
        /// The expected result will be a non zero vector where the presence of a sparrow in its list will affect
        /// the expected result.
        /// </summary>
        [TestMethod]
        public void TestCohesion_SparrowListSize3_ReturnsNonZeroCohesionVector()
        {
            // ARRANGE
            List<Sparrow> sparrows = new List<Sparrow>();
            sparrows.Add(new Sparrow(1, 1, 2, 3));
            sparrows.Add(new Sparrow(2, 2, 2, 3));
            sparrows.Add(new Sparrow(3, 2, 2, 3));
            Sparrow testSparrow = new Sparrow(2, 3, 2, 3);
            float expVx = -0.2747211158275604f;
            float expVy = -0.9615239500999451f;

            // ACT
            Vector2 res = testSparrow.Cohesion(sparrows);

            // ASSERT
            Assert.AreEqual(expVx, res.Vx, 0.01);
            Assert.AreEqual(expVy, res.Vy, 0.01);
        }

        /// <summary>
        /// This test will test whether the method returns a zero vector for a list of sparrows not in the 
        /// neighbour radius.
        /// </summary>
        [TestMethod]
        public void TestCohesion_SparrowListSize3_ReturnsZeroCohesionVector()
        {
            // ARRANGE
            List<Sparrow> sparrows = new List<Sparrow>();
            sparrows.Add(new Sparrow(World.NeighbourRadius + 1, World.NeighbourRadius + 1, 2, 3));
            sparrows.Add(new Sparrow(World.NeighbourRadius + 2, World.NeighbourRadius + 2, 2, 3));
            sparrows.Add(new Sparrow(World.NeighbourRadius + 3, World.NeighbourRadius + 2, 2, 3));
            Sparrow testSparrow = new Sparrow(2, 3, 2, 3);
            float expVx = 0;
            float expVy = 0;

            // ACT
            Vector2 res = testSparrow.Cohesion(sparrows);

            // ASSERT
            Assert.AreEqual(expVx, res.Vx, 0.01);
            Assert.AreEqual(expVy, res.Vy, 0.01);
        }

        /// <summary>
        /// This test will test the avoidance of a sparrow between itself and a list of sparrows.
        /// The expected result is a non zero vector.
        /// </summary>
        [TestMethod]
        public void TestAvoidance_SparrowListSize3_ReturnsNonZeroAvoidanceVector()
        {
            // ARRANGE
            List<Sparrow> sparrows = new List<Sparrow>();
            sparrows.Add(new Sparrow(1, 1, 2, 3));
            sparrows.Add(new Sparrow(2, 2, 2, 3));
            sparrows.Add(new Sparrow(3, 2, 2, 3));
            Sparrow testSparrow = new Sparrow(2, 3, 2, 3);
            float expVx = -0.15596258640289307f;
            float expVy = 0.987762987613678f;

            // ACT
            Vector2 res = testSparrow.Avoidance(sparrows);

            // ASSERT
            Assert.AreEqual(expVx, res.Vx, 0.01);
            Assert.AreEqual(expVy, res.Vy, 0.01);
        }

        /// <summary>
        /// This test will test the avoidance of a sparrow between itself and a list of sparrows.
        /// Since the sparrows are out of the avoidance radius the expected vector returned is a zero vector.
        /// </summary>
        [TestMethod]
        public void TestAvoidance_SparrowListSize3_ReturnsZeroVector()
        {
            // ARRANGE
            List<Sparrow> sparrows = new List<Sparrow>();
            sparrows.Add(new Sparrow(World.AvoidanceRadius + 1, World.AvoidanceRadius + 1, 2, 3));
            sparrows.Add(new Sparrow(World.AvoidanceRadius + 2, World.AvoidanceRadius + 2, 2, 3));
            sparrows.Add(new Sparrow(World.AvoidanceRadius + 3, World.AvoidanceRadius + 2, 2, 3));
            Sparrow testSparrow = new Sparrow(0, 0, 2, 3);
            float expVx = 0;
            float expVy = 0;

            // ACT
            Vector2 res = testSparrow.Avoidance(sparrows);

            // ASSERT
            Assert.AreEqual(expVx, res.Vx, 0.01);
            Assert.AreEqual(expVy, res.Vy, 0.01);
        }

        /// <summary>
        /// This test will test the flee raven function where the input will be a raven.
        /// Since the raven will be within the radius of the flee radius it will not return a zero vector
        /// </summary>
        [TestMethod]
        public void TestFleeRaven_Raven_ReturnsNonZeroVector()
        {
            // ARRANGE
            Raven testRaven = new Raven(1, 2, 2, 3);
            Sparrow testSparrow = new Sparrow(0, 0, 2, 3);
            float expVx = -0.44721361994743347f;
            float expVy = -0.8944272398948669f;

            // ACT
            Vector2 res = testSparrow.FleeRaven(testRaven);

            // ASSERT
            Assert.AreEqual(expVx, res.Vx, 0.01);
            Assert.AreEqual(expVy, res.Vy, 0.01);
        }

        /// <summary>
        /// This test will test the flee raven function where the input will be a raven.
        /// Since the raven will be outside of the flee radius it should return a zero vector
        /// </summary>
        [TestMethod]
        public void TestFleeRaven_Raven_ReturnsZeroVector()
        {
            // ARRANGE
            Raven testRaven = new Raven(World.FleeRadius + 1, World.FleeRadius + 2, 2, 3);
            Sparrow testSparrow = new Sparrow(0, 0, 2, 3);
            float expVx = 0;
            float expVy = 0;

            // ACT
            Vector2 res = testSparrow.FleeRaven(testRaven);

            // ASSERT
            Assert.AreEqual(expVx, res.Vx, 0.01);
            Assert.AreEqual(expVy, res.Vy, 0.01);
        }

        /// <summary>
        /// This test will test the flee raven function. It will test whether the output is the nornalized value of the current 
        /// velocity.
        /// </summary>
        [TestMethod]
        public void TestFleeRaven_RavenSamePositionAsSparrow_ReturnsZeroVector()
        {
            // ARRANGE
            Raven testRaven = new Raven(1, 2, 2, 3);
            Sparrow testSparrow = new Sparrow(1, 2, 2, 3);
            Vector2 expVector = Vector2.SafeNormalize(new Vector2(2, 3));
            float expVx = expVector.Vx;
            float expVy = expVector.Vy;

            // ACT
            Vector2 res = testSparrow.FleeRaven(testRaven);

            // ASSERT
            Assert.AreEqual(expVx, res.Vx, 0.01);
            Assert.AreEqual(expVy, res.Vy, 0.01);
        }
    }
}