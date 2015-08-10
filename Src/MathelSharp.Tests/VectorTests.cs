namespace MathelSharp.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void CreateWithValues()
        {
            Vector vector = new Vector(new double[] { 1.0, 2.0, 3.0 });

            Assert.AreEqual(3, vector.Size);

            var elements = vector.Elements;

            Assert.AreEqual(1.0, elements[0]);
            Assert.AreEqual(2.0, elements[1]);
            Assert.AreEqual(3.0, elements[2]);
        }

        [TestMethod]
        public void GetElement()
        {
            Vector vector = new Vector(new double[] { 1.0, 2.0, 3.0 });

            Assert.AreEqual(3, vector.Size);

            Assert.AreEqual(1.0, vector.GetElement(0));
            Assert.AreEqual(2.0, vector.GetElement(1));
            Assert.AreEqual(3.0, vector.GetElement(2));
        }

        [TestMethod]
        public void EqualsAndHashCode()
        {
            Vector vector1 = new Vector(new double[] { 1.0, 2.0, 3.0 });
            Vector vector2 = new Vector(new double[] { 1.0, 2.0, 3.0 });
            Vector vector3 = new Vector(new double[] { 1.0, 2.0, 3.0, 4.0 });
            Vector vector4 = new Vector(new double[] { 1.0, 2.0, 4.0 });

            Assert.IsTrue(vector1.Equals(vector2));
            Assert.IsTrue(vector2.Equals(vector1));

            Assert.AreEqual(vector2.GetHashCode(), vector1.GetHashCode());

            Assert.IsFalse(vector1.Equals(vector3));
            Assert.IsFalse(vector1.Equals(vector4));
            Assert.IsFalse(vector3.Equals(vector1));
            Assert.IsFalse(vector4.Equals(vector1));

            Assert.IsFalse(vector1.Equals(null));
            Assert.IsFalse(vector1.Equals(42));
            Assert.IsFalse(vector1.Equals("foo"));
        }

        [TestMethod]
        public void ElementsAreACopy()
        {
            Vector vector = new Vector(new double[] { 1.0, 2.0, 3.0 });

            Assert.AreEqual(3, vector.Size);

            var elements = vector.Elements;

            elements[0]++;
            elements[1]++;
            elements[2]++;

            var elements2 = vector.Elements;

            Assert.AreEqual(1.0, elements2[0]);
            Assert.AreEqual(2.0, elements2[1]);
            Assert.AreEqual(3.0, elements2[2]);
        }

        [TestMethod]
        public void SimpleAdd()
        {
            Vector vector1 = new Vector(new double[] { 1.0, 2.0, 3.0 });
            Vector vector2 = new Vector(new double[] { 4.0, 5.0, 6.0 });

            Vector vector = vector1.Add(vector2);
            Assert.AreEqual(3, vector.Size);

            var elements = vector.Elements;

            Assert.AreEqual(1.0 + 4.0, elements[0]);
            Assert.AreEqual(2.0 + 5.0, elements[1]);
            Assert.AreEqual(3.0 + 6.0, elements[2]);
        }

        [TestMethod]
        public void AddRaiseExceptionIfVectorsHaveDifferenteLengths()
        {
            Vector vector1 = new Vector(new double[] { 1.0, 2.0, 3.0 });
            Vector vector2 = new Vector(new double[] { 4.0, 5.0, 6.0, 7.0 });

            try
            {
                vector1.Add(vector2);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Vectors have different lengths", ex.Message);
            }
        }

        [TestMethod]
        public void SimpleSubtract()
        {
            Vector vector1 = new Vector(new double[] { 1.0, 2.0, 3.0 });
            Vector vector2 = new Vector(new double[] { 4.0, 5.0, 6.0 });

            Vector vector = vector1.Subtract(vector2);
            Assert.AreEqual(3, vector.Size);

            var elements = vector.Elements;

            Assert.AreEqual(1.0 - 4.0, elements[0]);
            Assert.AreEqual(2.0 - 5.0, elements[1]);
            Assert.AreEqual(3.0 - 6.0, elements[2]);
        }

        [TestMethod]
        public void SubtractRaiseExceptionIfVectorsHaveDifferenteLengths()
        {
            Vector vector1 = new Vector(new double[] { 1.0, 2.0, 3.0 });
            Vector vector2 = new Vector(new double[] { 4.0, 5.0, 6.0, 7.0 });

            try
            {
                vector1.Subtract(vector2);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Vectors have different lengths", ex.Message);
            }
        }

        [TestMethod]
        public void SimpleNegate()
        {
            Vector vector1 = new Vector(new double[] { 1.0, 2.0, 3.0 });

            Vector vector = vector1.Negate();
            Assert.AreEqual(3, vector.Size);

            var elements = vector.Elements;

            Assert.AreEqual(-1.0, elements[0]);
            Assert.AreEqual(-2.0, elements[1]);
            Assert.AreEqual(-3.0, elements[2]);
        }

        [TestMethod]
        public void SimpleInnerProduct()
        {
            Vector vector1 = new Vector(new double[] { 1.0, 2.0, 3.0 });
            Vector vector2 = new Vector(new double[] { 4.0, 5.0, 6.0 });

            double result = vector1.InnerProduct(vector2);
            Assert.AreEqual((1.0 * 4.0) + (2.0 * 5.0) + (3.0 * 6.0), result);
        }

        [TestMethod]
        public void InnerProductRaiseExceptionIfVectorsHaveDifferenteLengths()
        {
            Vector vector1 = new Vector(new double[] { 1.0, 2.0, 3.0 });
            Vector vector2 = new Vector(new double[] { 4.0, 5.0, 6.0, 7.0 });

            try
            {
                vector1.InnerProduct(vector2);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Vectors have different lengths", ex.Message);
            }
        }
    }
}
