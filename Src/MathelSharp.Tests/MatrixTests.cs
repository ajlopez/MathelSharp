namespace MathelSharp.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void CreateWithValues()
        {
            Matrix matrix = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });

            Assert.AreEqual(4, matrix.Size);

            var elements = matrix.Elements;

            Assert.AreEqual(1.0, elements[0][0]);
            Assert.AreEqual(2.0, elements[0][1]);
            Assert.AreEqual(3.0, elements[1][0]);
            Assert.AreEqual(4.0, elements[1][1]);
        }

        [TestMethod]
        public void GetElement()
        {
            Matrix matrix = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });

            Assert.AreEqual(4, matrix.Size);

            Assert.AreEqual(1.0, matrix.GetElement(0, 0));
            Assert.AreEqual(2.0, matrix.GetElement(0, 1));
            Assert.AreEqual(3.0, matrix.GetElement(1, 0));
            Assert.AreEqual(4.0, matrix.GetElement(1, 1));
        }

        [TestMethod]
        public void EqualsAndHashCode()
        {
            Matrix matrix1 = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });
            Matrix matrix2 = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });
            Matrix matrix3 = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 5.0 } });
            Matrix matrix4 = new Matrix(new double[][] { new double[] { 1.0, 2.0, 3.0 }, new double[] { 3.0, 4.0, 5.0 } });
            Matrix matrix5 = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 }, new double[] { 5.0, 6.0 } });

            Assert.IsTrue(matrix1.Equals(matrix2));
            Assert.IsTrue(matrix2.Equals(matrix1));

            Assert.AreEqual(matrix2.GetHashCode(), matrix1.GetHashCode());

            Assert.IsFalse(matrix1.Equals(matrix3));
            Assert.IsFalse(matrix1.Equals(matrix4));
            Assert.IsFalse(matrix1.Equals(matrix5));
            Assert.IsFalse(matrix3.Equals(matrix1));
            Assert.IsFalse(matrix4.Equals(matrix1));
            Assert.IsFalse(matrix5.Equals(matrix1));

            Assert.IsFalse(matrix1.Equals(null));
            Assert.IsFalse(matrix1.Equals(42));
            Assert.IsFalse(matrix1.Equals("foo"));
        }

        [TestMethod]
        public void CreateUnityMatrix()
        {
            Matrix matrix = Matrix.Unity(2);

            Assert.AreEqual(4, matrix.Size);

            var elements = matrix.Elements;

            Assert.AreEqual(1.0, elements[0][0]);
            Assert.AreEqual(0.0, elements[0][1]);
            Assert.AreEqual(0.0, elements[1][0]);
            Assert.AreEqual(1.0, elements[1][1]);
        }

        [TestMethod]
        public void ElementsIsACopy()
        {
            Matrix matrix = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });

            var elements = matrix.Elements;

            for (int k = 0; k < 2; k++)
                for (int j = 0; j < 2; j++)
                    elements[k][j]++;

            var elements2 = matrix.Elements;

            Assert.AreEqual(1.0, elements2[0][0]);
            Assert.AreEqual(2.0, elements2[0][1]);
            Assert.AreEqual(3.0, elements2[1][0]);
            Assert.AreEqual(4.0, elements2[1][1]);
        }

        [TestMethod]
        public void Negate()
        {
            Matrix matrix = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });

            Matrix result = matrix.Negate();

            Assert.AreEqual(4, result.Size);

            var elements = result.Elements;

            Assert.AreEqual(-1.0, elements[0][0]);
            Assert.AreEqual(-2.0, elements[0][1]);
            Assert.AreEqual(-3.0, elements[1][0]);
            Assert.AreEqual(-4.0, elements[1][1]);
        }

        [TestMethod]
        public void Add()
        {
            Matrix matrix1 = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });
            Matrix matrix2 = new Matrix(new double[][] { new double[] { 5.0, 6.0 }, new double[] { 7.0, 8.0 } });

            Matrix matrix = matrix1.Add(matrix2);

            Assert.AreEqual(4, matrix.Size);

            var elements = matrix.Elements;

            Assert.AreEqual(1.0 + 5.0, elements[0][0]);
            Assert.AreEqual(2.0 + 6.0, elements[0][1]);
            Assert.AreEqual(3.0 + 7.0, elements[1][0]);
            Assert.AreEqual(4.0 + 8.0, elements[1][1]);
        }

        [TestMethod]
        public void AddRaiseExceptionIfDifferentRowSize()
        {
            Matrix matrix1 = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });
            Matrix matrix2 = new Matrix(new double[][] { new double[] { 5.0, 6.0 }, new double[] { 7.0, 8.0 }, new double[] { 9.0, 10.0 } });

            try
            {
                matrix1.Add(matrix2);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Matrices have different sizes", ex.Message);
            }
        }

        [TestMethod]
        public void AddRaiseExceptionIfDifferentColumnSize()
        {
            Matrix matrix1 = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });
            Matrix matrix2 = new Matrix(new double[][] { new double[] { 5.0, 6.0, 0.0 }, new double[] { 7.0, 8.0, 0.0 } });

            try
            {
                matrix1.Add(matrix2);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Matrices have different sizes", ex.Message);
            }
        }

        [TestMethod]
        public void Subtract()
        {
            Matrix matrix1 = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });
            Matrix matrix2 = new Matrix(new double[][] { new double[] { 5.0, 6.0 }, new double[] { 7.0, 8.0 } });

            Matrix matrix = matrix1.Subtract(matrix2);

            Assert.AreEqual(4, matrix.Size);

            var elements = matrix.Elements;

            Assert.AreEqual(1.0 - 5.0, elements[0][0]);
            Assert.AreEqual(2.0 - 6.0, elements[0][1]);
            Assert.AreEqual(3.0 - 7.0, elements[1][0]);
            Assert.AreEqual(4.0 - 8.0, elements[1][1]);
        }

        [TestMethod]
        public void SubtractRaiseExceptionIfDifferentRowSize()
        {
            Matrix matrix1 = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });
            Matrix matrix2 = new Matrix(new double[][] { new double[] { 5.0, 6.0 }, new double[] { 7.0, 8.0 }, new double[] { 9.0, 10.0 } });

            try
            {
                matrix1.Subtract(matrix2);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Matrices have different sizes", ex.Message);
            }
        }

        [TestMethod]
        public void SubtractRaiseExceptionIfDifferentColumnSize()
        {
            Matrix matrix1 = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });
            Matrix matrix2 = new Matrix(new double[][] { new double[] { 5.0, 6.0, 0.0 }, new double[] { 7.0, 8.0, 0.0 } });

            try
            {
                matrix1.Subtract(matrix2);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Matrices have different sizes", ex.Message);
            }
        }

        [TestMethod]
        public void Multiply()
        {
            Matrix matrix1 = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });
            Matrix matrix2 = new Matrix(new double[][] { new double[] { 5.0, 6.0 }, new double[] { 7.0, 8.0 } });

            Matrix matrix = matrix1.Multiply(matrix2);

            Assert.AreEqual(4, matrix.Size);

            var elements = matrix.Elements;

            Assert.AreEqual((1.0 * 5.0) + (2.0 * 7.0), elements[0][0]);
            Assert.AreEqual((1.0 * 6.0) + (2.0 * 8.0), elements[0][1]);
            Assert.AreEqual((3.0 * 5.0) + (4.0 * 7.0), elements[1][0]);
            Assert.AreEqual((3.0 * 6.0) + (4.0 * 8.0), elements[1][1]);
        }

        [TestMethod]
        public void MultiplyRaiseException()
        {
            Matrix matrix1 = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });
            Matrix matrix2 = new Matrix(new double[][] { new double[] { 5.0, 6.0 }, new double[] { 7.0, 8.0 }, new double[] { 9.0, 10.0 } });

            try {
                matrix1.Multiply(matrix2);
                Assert.Fail();
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Matrices cannot be multiplied", ex.Message);
            }
        }

        [TestMethod]
        public void Determinant()
        {
            Matrix matrix = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 } });

            double result = matrix.Determinant();

            Assert.AreEqual((1.0 * 4.0) - (2.0 * 3.0), result);
        }

        [TestMethod]
        public void DeterminantRaiseException()
        {
            Matrix matrix = new Matrix(new double[][] { new double[] { 1.0, 2.0 }, new double[] { 3.0, 4.0 }, new double[] { 5.0, 6.0 } });

            try
            {
                matrix.Determinant();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Matrix is not square", ex.Message);
            }
        }
    }
}
