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
            Matrix matrix = new Matrix(new double[][] { new double[] { 1.0, 2.0 } , new double[] { 3.0, 4.0 } });

            Assert.AreEqual(4, matrix.Size);

            var elements = matrix.Elements;

            Assert.AreEqual(1.0, elements[0][0]);
            Assert.AreEqual(2.0, elements[0][1]);
            Assert.AreEqual(3.0, elements[1][0]);
            Assert.AreEqual(4.0, elements[1][1]);
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
    }
}
