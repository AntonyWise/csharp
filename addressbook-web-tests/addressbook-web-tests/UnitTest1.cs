using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAddressBookTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSquare()
        {
            Square s1 = new Square(5);
            Square s2 = new Square(10);
            Square s3 = s1;

            Assert.AreEqual(s1.Size, 5);
            Assert.AreEqual(s2.Size, 10);
            Assert.AreEqual(s3.Size, 5);

            s3.Size = 15;
            Assert.AreEqual(s1.Size, 15);

            s2.Color = true;
        }

        [TestMethod]
        public void TestCircle()
        {
            Circle c1 = new Circle(5);
            Circle c2 = new Circle(10);
            Circle c3 = c1;

            Assert.AreEqual(c1.Radius, 5);
            Assert.AreEqual(c2.Radius, 10);
            Assert.AreEqual(c3.Radius, 5);

            c3.Radius = 15;
            Assert.AreEqual(c1.Radius, 15);

            c2.Color = true;
        }
    }
}
