using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{

    [TestClass]
    class TriangleTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(4, 0);
            var p3 = new Point(4, 5);



            var myTriangle = new Triangle(p1, p2, p3);

            Assert.AreSame(p1, myTriangle.Point1);
            Assert.AreSame(p2, myTriangle.Point2);
            Assert.AreSame(p3, myTriangle.Point3);

            myTriangle = new Triangle(p1, p1, p3);
            Assert.AreSame(p1, myTriangle.Point1);
            Assert.AreSame(p2, myTriangle.Point2);
            Assert.AreSame(p3, myTriangle.Point3);

            p1 = new Point(0.5, 0.5);
            p2 = new Point(4.5, 0.5);
            p3 = new Point(4.5, 5.5);
            myTriangle = new Triangle(p1, p1, p3);
            Assert.AreSame(p1, myTriangle.Point1);
            Assert.AreSame(p2, myTriangle.Point2);
            Assert.AreSame(p3, myTriangle.Point3);

            myTriangle = new Triangle(0.5, 0.5, 4.5, 0.5, 4.5, 5.5);
            Assert.AreEqual(0.5, myTriangle.Point1.X, 0);
            Assert.AreEqual(0.5, myTriangle.Point1.Y, 0);
            Assert.AreEqual(4.5, myTriangle.Point2.X, 0);
            Assert.AreEqual(0.5, myTriangle.Point2.Y, 0);
            Assert.AreEqual(4.5, myTriangle.Point3.X, 0);
            Assert.AreEqual(5.5, myTriangle.Point3.Y, 0);
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
                new Triangle(p1, null, null);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid point", e.Message);
            }

            try
            {
                new Triangle(null, p2, null);
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

            var myTriangle = new Triangle(p1, p2, p3);

            myTriangle.Move(3, 4);
            Assert.AreEqual(3, myTriangle.Point1.X, 0);
            Assert.AreEqual(4, myTriangle.Point1.Y, 0);
            Assert.AreEqual(7, myTriangle.Point2.X, 0);
            Assert.AreEqual(4, myTriangle.Point2.Y, 0);
            Assert.AreEqual(7, myTriangle.Point3.X, 0);
            Assert.AreEqual(9, myTriangle.Point3.Y, 0);

        }

        [TestMethod]
        public void TestComputeArea()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(4, 0);
            var p3 = new Point(4, 5);
            var myTriangle = new Triangle(p1, p2, p3);
            Assert.AreEqual(10, myTriangle.ComputeArea(), 0);
        }


        [TestMethod]
        [ExpectedException(typeof(ShapeException),
            "Invalid triangle")]
        public void TestValidateLine()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(1, 2);
            var p3 = new Point(1, 2);

            var myTriangle = new Triangle(p1, p2, p3);
        }
    }
}