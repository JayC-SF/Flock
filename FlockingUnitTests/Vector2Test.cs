using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlockingBackend;
namespace FlockingUnitTests
{
    /// <summary>
    /// This class tests the implemented methods within Vector2 class.
    /// </summary>
    [TestClass]
    public class Vector2dTests
    {
        /// <summary>
        /// This method tests the initialization of the constructor.
        /// It evaluates the initialization of the Vx and Vy properties.
        /// </summary>
        /// <param name="x">X parameter for initialization</param>
        /// <param name="y">Y parameter for initialization</param>
        [DataTestMethod]
        [DataRow(1f, 2f)]
        [DataRow(-1f, 2.3f)]
        [DataRow(100.5f, 2.5f)]
        public void Constructor_FloatNumber_SetsFields(float x, float y)
        {
            // ARRANGE
            Vector2 v = new Vector2(x, y);
            // ACT
            float resX = v.Vx;
            float resY = v.Vy;
            // ASSERT
            Assert.AreEqual(x, resX, 0.01);
            Assert.AreEqual(y, resY, 0.01);
        }
        /// <summary>
        /// This function tests the addition operator of the Vector2 class.
        /// It initializes 2 vector, and adds them together. The result vector
        /// is compared with the expected values in the given properties expX, expY.
        /// </summary>
        /// <param name="x1">X property for the first vector</param>
        /// <param name="y1">Y property for the first vector</param>
        /// <param name="x2">X property for the second vector</param>
        /// <param name="y2">Y property for the second vector</param>
        /// <param name="expX">Expected X property value for the result vector</param>
        /// <param name="expY">Expected Y property value for the result vector</param>
        [DataTestMethod]
        [DataRow(1, 2, 2, 3, 3, 5)]
        [DataRow(-1, 3, -2, -3, -3, 0)]
        public void PlusOperator_XAndYProperties_ReturnsVectorSum(float x1, float y1, float x2, float y2, float expX, float expY)
        {
            // ARRANGE
            Vector2 v1 = new Vector2(x1, y1);
            Vector2 v2 = new Vector2(x2, y2);
            // ACT
            Vector2 res = v1 + v2;
            // ASSERT
            Assert.AreEqual(expX, res.Vx, 0.01);
            Assert.AreEqual(expY, res.Vy, 0.01);
        }

        /// <summary>
        /// This function tests the substraction operator of the Vector2 class.
        /// It initializes 2 vector, and substracts them. The result vector
        /// is compared with the expected values in the given properties expX, expY.
        /// </summary>
        /// <param name="x1">X property for the first vector</param>
        /// <param name="y1">Y property for the first vector</param>
        /// <param name="x2">X property for the second vector</param>
        /// <param name="y2">Y property for the second vector</param>
        /// <param name="expX">Expected X property value for the result vector</param>
        /// <param name="expY">Expected Y property value for the result vector</param>
        [DataTestMethod]
        [DataRow(1, 2, 2, 3, -1, -1)]
        [DataRow(-1, 3, -2, -3, 1, 6)]
        [DataRow(10, 17, -2, -3, 12, 20)]
        [DataRow(10, 17, 2, 3, 8, 14)]
        public void MinusOperator_XAndYProperties_ReturnsVectorDifference(float x1, float y1, float x2, float y2, float expX, float expY)
        {
            // ARRANGE
            Vector2 v1 = new Vector2(x1, y1);
            Vector2 v2 = new Vector2(x2, y2);
            // ACT
            Vector2 res = v1 - v2;
            // ASSERT
            Assert.AreEqual(expX, res.Vx, 0.01);
            Assert.AreEqual(expY, res.Vy, 0.01);
        }

        [DataTestMethod]
        [DataRow(1, 2, 5, 5, 10)]
        [DataRow(-1, -2, 5, -5, -10)]
        /// <summary>
        /// This method will test if the vector multiplication of a scalar value works. 
        /// It will multiply a scalar number with a vector, the result should return a vector with its properties
        /// multiplied by the scalar value.
        /// </summary>
        /// <param name="x">X property for the vector</param>
        /// <param name="y">Y property for the vector</param>
        /// <param name="scalar">Scalar value to multiply the vector</param>
        /// <param name="expX">Expected X property value for the result vector</param>
        /// <param name="expY">Expected Y property value for the result vector</param>
        public void MultiplyOperatorScalarBeforeVector_XAndYProperties_ReturnsVectorProduct(float x, float y, float scalar, float expX, float expY)
        {
            // ARRANGE
            Vector2 v1 = new Vector2(x, y);
            // ACT
            // Multiply scalar before vector.
            Vector2 res = scalar * v1;
            // ASSERT
            Assert.AreEqual(expX, res.Vx, 0.01);
            Assert.AreEqual(expY, res.Vy, 0.01);
        }

        [DataTestMethod]
        [DataRow(1, 2, 5, 5, 10)]
        [DataRow(-1, -2, 5, -5, -10)]
        [DataRow(3, -2, 9, 27, -18)]
        /// <summary>
        /// This method will test if the scalar multiplication of a vector  works. 
        /// It will multiply a scalar number with a vector, the result should return a vector with its properties
        /// multiplied by the scalar value.
        /// It is the same test as the earlier one, however since the overriding of the multiplication is not
        /// commutative, this multiplication is also tested.
        /// </summary>
        /// <param name="x">X property for the vector</param>
        /// <param name="y">Y property for the vector</param>
        /// <param name="scalar">Scalar value to multiply the vector</param>
        /// <param name="expX">Expected X property value for the result vector</param>
        /// <param name="expY">Expected Y property value for the result vector</param>
        public void MultiplyOperatorScalarAfterVector_XAndYProperties_ReturnsVectorProduct(float x, float y, float scalar, float expX, float expY)
        {
            // ARRANGE
            Vector2 v1 = new Vector2(x, y);
            // ACT
            // Multiply scalar after vector.
            Vector2 res = v1 * scalar;
            // ASSERT
            Assert.AreEqual(expX, res.Vx, 0.01);
            Assert.AreEqual(expY, res.Vy, 0.01);
        }

        /// <summary>
        /// This method tests the dot product between 2 vectors. The result should be a float scalar value representing the 
        /// dot product between 2 vectors.
        /// </summary>
        /// <param name="x1">X property for the first vector</param>
        /// <param name="y1">Y property for the first vector</param>
        /// <param name="x2">X property for the second vector</param>
        /// <param name="y2">Y property for the second vector</param>
        /// <param name="exp">Expected dot product</param>
        [DataTestMethod]
        [DataRow(1, 2, 2, 3, 8)]
        [DataRow(-1, 3, -2, -3, -7)]
        [DataRow(10, 17, -2, -3, -71)]
        public void MultiplyOperator_XAndYProperties_ReturnsVectorDotProduct(float x1, float y1, float x2, float y2, float exp)
        {
            // ARRANGE
            Vector2 v1 = new Vector2(x1, y1);
            Vector2 v2 = new Vector2(x2, y2);
            // ACT
            float res = v1 * v2;
            // ASSERT
            Assert.AreEqual(exp, res, 0.01);
        }

        /// <summary>
        /// This method will test if the scalar division of a vector  works. 
        /// It will multiply a scalar number with a vector, the result should return a vector with its properties
        /// multiplied by the scalar value.
        /// It is the same test as the earlier one, however since the overriding of the multiplication is not
        /// commutative, this multiplication is also tested.
        /// </summary>
        /// <param name="x">X property for the vector</param>
        /// <param name="y">Y property for the vector</param>
        /// <param name="scalar">Scalar value to divide the vector</param>
        /// <param name="expX">Expected X property value for the result vector</param>
        /// <param name="expY">Expected Y property value for the result vector</param>
        [DataTestMethod]
        [DataRow(1, 2, 5, 0.2f, 0.4f)]
        [DataRow(-1, -2, 5, -0.2f, -0.4f)]
        [DataRow(3, -2, 8, 0.375f, -0.25f)]
        public void DivideOperator_XAndYProperties_ReturnsVectorQuotient(float x, float y, float scalar, float expX, float expY)
        {
            // ARRANGE
            Vector2 v1 = new Vector2(x, y);
            // ACT
            // Multiply scalar after vector.
            Vector2 res = v1 / scalar;
            // ASSERT
            Assert.AreEqual(expX, res.Vx, 0.01);
            Assert.AreEqual(expY, res.Vy, 0.01);
        }

        /// <summary>
        /// This function tests the DistanceSquared function in the Vector2 class.
        /// 2 Vectors are inserted as in put. If the <c>res</c> variable equals the exp variable
        /// the test passes.
        /// </summary>
        /// <param name="x1">X property for the first vector</param>
        /// <param name="y1">Y property for the first vector</param>
        /// <param name="x2">X property for the second vector</param>
        /// <param name="y2">Y property for the second vector</param>
        /// <param name="exp">Expected distance squared value.</param>
        [DataTestMethod]
        [DataRow(1, 2, 5, 0.2f, 19.24f)]        // (1-5)^2 + (2 - 0.2)^2 = 16 + 3.24 = 19.24
        [DataRow(-1, -2, 5, -0.2f, 39.24f)]     // (-1 - 5)^2 + (-2 - -0.2) = 39.24
        [DataRow(3, -2, 8, 0.375f, 30.640625f)] // (3 - 8)^2 + (-2 - 0.375)^2 = 30.640625
        public void DistanceSquared_2Vector_ReturnsSquaredDistanceBetweenVectors(float x1, float y1, float x2, float y2, float exp)
        {
            // ARRANGE
            Vector2 v1 = new Vector2(x1, y1);
            Vector2 v2 = new Vector2(x2, y2);
            // ACT
            float res = Vector2.DistanceSquared(v1, v2);
            // ASSERT
            Assert.AreEqual(exp, res, 0.01);
        }

        /// <summary>
        /// This function tests if the Magnitude helper function works as intended.
        /// </summary>
        /// <param name="x">X property of the vector</param>
        /// <param name="y">Y property for the vector</param>
        /// <param name="exp">Expected magnitude value</param>
        [DataTestMethod]
        [DataRow(1, 1, 1.41421356237f)]
        [DataRow(-1, 1, 1.41421356237f)]
        [DataRow(-5, 3, 5.83095189485f)]
        public void Magnitude_2dVector_ReturnsVectorMagnitude(float x, float y, float exp)
        {
            // ARRANGE
            Vector2 v = new Vector2(x, y);
            // ACT
            float mag = Vector2.Magnitude(v);
            // ASSERT
            Assert.AreEqual(exp, mag, 0.01);
        }
        /// <summary>
        /// This function tests if the Normalize function works as intended.
        /// </summary>
        /// <param name="x">X property of the vector</param>
        /// <param name="y">Y property for the vector</param>
        /// <param name="expX">Expected X property value from the Normalized Vector</param>
        /// <param name="expY">Expected Y property value from the Normalized Vector</param>
        [DataTestMethod]
        [DataRow(1, 1, 0.70710678118f, 0.70710678118f)]
        [DataRow(-1, 1, -0.70710678118f, 0.70710678118f)]
        [DataRow(-5, 3, -0.85749292571f, 0.51449575542f)]
        public void Normalize_2dVector_ReturnsNormalizedVector(float x, float y, float expX, float expY)
        {
            // ARRANGE
            Vector2 v = new Vector2(x, y);
            // ACT
            Vector2 res = Vector2.Normalize(v);
            // ASSERT
            Assert.AreEqual(expX, res.Vx, 0.01);
            Assert.AreEqual(expY, res.Vy, 0.01);
        }

        /// <summary>
        /// This function tests if the SafeNormalize function works as intended.
        /// </summary>
        /// <param name="x">X property of the vector</param>
        /// <param name="y">Y property for the vector</param>
        /// <param name="expX">Expected X property value from the Normalized Vector</param>
        /// <param name="expY">Expected Y property value from the Normalized Vector</param>
        [DataTestMethod]
        [DataRow(1, 1, 0.70710678118f, 0.70710678118f)]
        [DataRow(-1, 1, -0.70710678118f, 0.70710678118f)]
        [DataRow(-5, 3, -0.85749292571f, 0.51449575542f)]
        public void SafeNormalize_2dVector_ReturnsNormalizedVector(float x, float y, float expX, float expY)
        {
            // ARRANGE
            Vector2 v = new Vector2(x, y);
            // ACT
            Vector2 res = Vector2.SafeNormalize(v);
            // ASSERT
            Assert.AreEqual(expX, res.Vx, 0.01);
            Assert.AreEqual(expY, res.Vy, 0.01);
        }

        /// <summary>
        /// This function tests of the Normalize function works as intended. The function
        /// should return a zero vector if given a zero vector.
        /// </summary>
        /// <param name="x">X property of the vector</param>
        /// <param name="y">Y property for the vector</param>
        /// <param name="expX">Expected X property value from the Normalized Vector</param>
        /// <param name="expY">Expected Y property value from the Normalized Vector</param>
        [TestMethod]
        public void SafeNormalize_2dZeroVector_ReturnsZeroVector()
        {
            // ARRANGE
            float x = 0, y  = 0, expX = 0, expY = 0;
            Vector2 v = new Vector2(x, y);
            // ACT
            Vector2 res = Vector2.SafeNormalize(v);
            // ASSERT
            Assert.AreEqual(expX, res.Vx, 0.01);
            Assert.AreEqual(expY, res.Vy, 0.01);
        }
    }
}
