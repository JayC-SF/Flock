using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlockingBackend;
using System.Collections.Generic;

namespace FlockingUnitTests
{
    /// <summary>
    /// WorldTest tests all the fields and methods for the World class
    /// </summary>
    [TestClass]
    public class WorldTest
    {
        /// <summary>
        /// This method checks if the World class gets properly instantiated and checks if Sparrows and Raven are not null
        /// </summary>
        [TestMethod]
        public void WorldConstructorTest_InitializingWorldInstance_WorldObjectProperlyInitialized()
        {
            //ARRANGE & ACT
            World worldTest = new World();
            int expectedCount = World.InitialCount;
            List<Sparrow> sparrows = worldTest.Sparrows;

            //ASSERT
            foreach (var sparrow in sparrows)
            {
                Assert.IsInstanceOfType(sparrow, typeof(Sparrow));
            }
            Assert.AreEqual(expectedCount, sparrows.Count);
            Assert.IsNotNull(worldTest);
        }
    }
}