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
    }
}
