using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    class SquareTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(4, 0);
            var p3 = new Point(4, 5);
            var p4 = new Point(0, 5);


            var mySquare = new Square(p1, p2, p3, p4);

            Assert.AreSame(p1, mySquare.Point1);
            Assert.AreSame(p2, mySquare.Point2);
            Assert.AreSame(p3, mySquare.Point3);
            Assert.AreSame(p4, mySquare.Point4);

            mySquare = new Square(p1, p1, p3, p4);
            Assert.AreSame(p1, mySquare.Point1);
            Assert.AreSame(p2, mySquare.Point2);
            Assert.AreSame(p3, mySquare.Point3);
            Assert.AreSame(p4, mySquare.Point4);

            p1 = new Point(0.5, 0.5);
            p2 = new Point(4.5, 0.5);
            p3 = new Point(4.5, 5.5);
            p4 = new Point(0.5, 5.5);
            mySquare = new Square(p1, p1, p3, p4);
            Assert.AreSame(p1, mySquare.Point1);
            Assert.AreSame(p2, mySquare.Point2);
            Assert.AreSame(p3, mySquare.Point3);
            Assert.AreSame(p4, mySquare.Point4);

            mySquare = new Square(0.5, 0.5, 4.5, 0.5, 4.5, 5.5, 0.5, 5.5);
            Assert.AreEqual(0.5, mySquare.Point1.X, 0);
            Assert.AreEqual(0.5, mySquare.Point1.Y, 0);
            Assert.AreEqual(4.5, mySquare.Point2.X, 0);
            Assert.AreEqual(0.5, mySquare.Point2.Y, 0);
            Assert.AreEqual(4.5, mySquare.Point3.X, 0);
            Assert.AreEqual(5.5, mySquare.Point3.Y, 0);
            Assert.AreEqual(0.5, mySquare.Point4.X, 0);
            Assert.AreEqual(5.5, mySquare.Point4.Y, 0);
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(4, 10);
            var p3 = new Point(9, 7);
            var p4 = new Point(12, 3);

            try
            {
                new Square(p1, null, null, null);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid point", e.Message);
            }

            try
            {
                new Square(null, p2, null, null);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid point", e.Message);
            }
        }

        [TestMethod]
        public void TestMove()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(4, 0);
            var p3 = new Point(4, 5);
            var p4 = new Point(0, 5);
            var mySquare = new Square(p1, p2, p3, p4);

            mySquare.Move(3, 4);
            Assert.AreEqual(3, mySquare.Point1.X, 0);
            Assert.AreEqual(4, mySquare.Point1.Y, 0);
            Assert.AreEqual(7, mySquare.Point2.X, 0);
            Assert.AreEqual(4, mySquare.Point2.Y, 0);
            Assert.AreEqual(7, mySquare.Point3.X, 0);
            Assert.AreEqual(9, mySquare.Point3.Y, 0);
            Assert.AreEqual(3, mySquare.Point4.X, 0);
            Assert.AreEqual(9, mySquare.Point4.Y, 0);
        }

        [TestMethod]
        public void TestComputeArea()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(4, 0);
            var p3 = new Point(4, 5);
            var p4 = new Point(0, 5);
            var mySquare = new Square(p1, p2, p3, p4);
            Assert.AreEqual(20, mySquare.ComputeArea(), 0);
        }


        [TestMethod]
        [ExpectedException(typeof(ShapeException),
            "Invalid rectangle")]
        public void TestValidateLine()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(4, 10);
            var p3 = new Point(9, 7);
            var p4 = new Point(12, 3);
            var mySquare = new Square(p1, p2, p3, p4);
        }
    }
}
