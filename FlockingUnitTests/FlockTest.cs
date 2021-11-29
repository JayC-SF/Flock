using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlockingBackend;
using System.Collections.Generic;

namespace FlockingUnitTests
{
    /// <summary>
    /// FlockTest tests the Subscribe() and RaiseMoveEvents() of the Flock object 
    /// </summary>
    [TestClass]
    public class FlockTest
    {
        /// <summary>
        /// This method tests if the initialized Flock object isn't null
        /// </summary>
        [TestMethod]
        public void InitializeConstructorTest_Empty_CheckIfFlockIsNull()
        {
            //ARRANGE & ACT
            Flock flockTest = new Flock();

            //ASSERT
            Assert.IsNotNull(flockTest);
        }

        /// <summary>
        /// This method tests if the Bird's Velocities have changed after succesfully subscribing and invoking the events
        /// </summary>
        [DataTestMethod]
        [DataRow(1f, 2f, 1, 1, 3f, 4f, 2, 2)]
        public void RaiseMoveEventsTest_2SparrowsAndRaven_CheckIfVelocityHasChanged(float sparrowTestPosX, float sparrowTestPosY, float sparrowTestVelX, float sparrowTestVelY, float sparrowTest2PosX, float sparrowTest2PosY, float sparrowTest2VelX, float sparrowTest2VelY)
        {
            //ARRANGE
            Flock flockTest = new Flock();
            Sparrow sparrowTest = new Sparrow(sparrowTestPosX, sparrowTestPosY, sparrowTestVelX, sparrowTestVelY);
            Sparrow sparrowTest2 = new Sparrow(sparrowTest2PosX, sparrowTest2PosY, sparrowTest2VelX, sparrowTest2VelY);
            Sparrow sparrowTestZeroVelocity = new Sparrow(10, 10, 0, 0); //velocity of 0
            List<Sparrow> sparrowsTest = new List<Sparrow>();
            sparrowsTest.Add(sparrowTest);
            sparrowsTest.Add(sparrowTest2);
            Raven ravenTest = new Raven(100f, 100f, 0, 0);

            //ACT
            foreach (Sparrow sparrow in sparrowsTest)
            {
                flockTest.Subscribe(sparrow.CalculateBehaviour, sparrow.Move, sparrow.CalculateRavenAvoidance);
            }
            flockTest.RaiseMoveEvents(sparrowsTest, ravenTest);

            //ASSERT
            Assert.AreNotEqual(sparrowTest.Position.Vx, sparrowTestPosX);
            Assert.AreNotEqual(sparrowTest.Position.Vy, sparrowTestPosY);
            Assert.AreNotEqual(sparrowTest.Velocity.Vx, sparrowTestVelX);
            Assert.AreNotEqual(sparrowTest.Velocity.Vy, sparrowTestVelY);
            Assert.AreNotEqual(sparrowTest2.Position.Vx, sparrowTest2PosX);
            Assert.AreNotEqual(sparrowTest2.Position.Vy, sparrowTest2PosY);
            Assert.AreNotEqual(sparrowTest2.Velocity.Vx, sparrowTest2VelX);
            Assert.AreNotEqual(sparrowTest2.Velocity.Vy, sparrowTest2VelY);

            Assert.AreEqual(sparrowTestZeroVelocity.Position.Vx, 10);
            Assert.AreEqual(sparrowTestZeroVelocity.Position.Vy, 10);
            Assert.AreEqual(sparrowTestZeroVelocity.Velocity.Vx, 0);
            Assert.AreEqual(sparrowTestZeroVelocity.Velocity.Vy, 0);
        }

        /// <summary>
        /// This method checks if the Bird's Velocities have not changed if the events gets invoked without subscribing
        /// </summary>
        [TestMethod]
        public void RaiseMoveEventsTest_SparrowTestsWithoutSubscribing_CheckIfVelocityIsStillZero()
        {
            //ARRANGE
            Flock flockTest = new Flock();
            Sparrow sparrowTest = new Sparrow(1f, 2f, 0, 0); //velocity of 0
            Sparrow sparrowTest2 = new Sparrow(3f, 4f, 0, 0); //velocity of 0
            List<Sparrow> sparrowsTest = new List<Sparrow>();
            sparrowsTest.Add(sparrowTest);
            sparrowsTest.Add(sparrowTest2);
            Raven ravenTest = new Raven(100f, 100f, 0, 0);

            //ACT
            flockTest.RaiseMoveEvents(sparrowsTest, ravenTest);

            //ASSERT
            Assert.AreEqual(sparrowTest.Velocity.Vx, 0);
            Assert.AreEqual(sparrowTest.Velocity.Vy, 0);
            Assert.AreEqual(sparrowTest2.Velocity.Vx, 0);
            Assert.AreEqual(sparrowTest2.Velocity.Vy, 0);
        }

        /// <summary>
        /// This method checks if the program does not throw if it subscribes successfully but invokes using null params
        /// </summary>
        [TestMethod]
        public void RaiseMoveEventsTest_ParamsAreNull_DoesNotThrowsNullReferenceException()
        {
            //ARRANGE
            Flock flockTest = new Flock();
            Sparrow sparrowTest = new Sparrow(1f, 2f, 0, 0); //velocity of 0
            Sparrow sparrowTest2 = new Sparrow(3f, 4f, 0, 0); //velocity of 0
            List<Sparrow> sparrowsTest = new List<Sparrow>();
            sparrowsTest.Add(sparrowTest);
            sparrowsTest.Add(sparrowTest2);
            Raven ravenTest = new Raven(100f, 100f, 0, 0);

            //ACT & ASSERT
            foreach (Sparrow sparrow in sparrowsTest)
            {
                flockTest.Subscribe(sparrow.CalculateBehaviour, sparrow.Move, sparrow.CalculateRavenAvoidance);
            }
            flockTest.RaiseMoveEvents(null, null); // Testing if sparrows and raven are null - should not throw exception
        }
    }
}