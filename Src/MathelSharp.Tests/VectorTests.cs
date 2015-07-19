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
    }
}
