using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    public class EllipseTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            var ellipse = new Ellipse(1, 3, 2.5, 3.5);
            Assert.AreEqual(1, ellipse.Center.X);
            Assert.AreEqual(3, ellipse.Center.Y);
            Assert.AreEqual(2.5, ellipse.horizontalRadius);
            Assert.AreEqual(3.5, ellipse.verticalRadius);

            ellipse = new Ellipse(new Point(1.23, 4.56), 7.89, 2.75);
            Assert.AreEqual(1.23, ellipse.Center.X);
            Assert.AreEqual(4.56, ellipse.Center.Y);
            Assert.AreEqual(7.89, ellipse.horizontalRadius);
            Assert.AreEqual(2.75, ellipse.verticalRadius);
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            try
            {
                new Ellipse(null, 2.5, 2.75);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid center point", e.Message);
            }

            try
            {
                new Ellipse(new Point(1, 2), double.PositiveInfinity, double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }

            try
            {
                new Ellipse(new Point(1, 2), double.NegativeInfinity, double.NegativeInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }

            try
            {
                new Ellipse(new Point(1, 2), Double.NaN, Double.NaN);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }

            try
            {
                new Ellipse(double.PositiveInfinity, 2, 3, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                new Ellipse(double.NegativeInfinity, 2, 3, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                new Ellipse(Double.NaN, 2, 3, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                new Ellipse(1, double.PositiveInfinity, 3, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                new Ellipse(1, double.NegativeInfinity, 3, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                new Ellipse(1, double.NaN, 3, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                new Ellipse(1, 2, double.PositiveInfinity, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }

            try
            {
                new Ellipse(1, 2, double.PositiveInfinity, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }

            try
            {
                new Ellipse(1, 2, Double.NaN, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }
        }

        [TestMethod]
        public void TestMove()
        {
            Ellipse myEllipse = new Ellipse(1, 2, 5, 6);
            Assert.AreEqual(1, myEllipse.Center.X, 0);
            Assert.AreEqual(2, myEllipse.Center.Y, 0);
            Assert.AreEqual(5, myEllipse.horizontalRadius, 0);
            Assert.AreEqual(6, myEllipse.verticalRadius, 0);

            myEllipse.Move(3, 4);
            Assert.AreEqual(4, myEllipse.Center.X, 0);
            Assert.AreEqual(6, myEllipse.Center.Y, 0);
            Assert.AreEqual(5, myEllipse.horizontalRadius, 0);
            Assert.AreEqual(6, myEllipse.verticalRadius, 0);

            myEllipse.Move(0.123, 0.456);
            Assert.AreEqual(4.123, myEllipse.Center.X, 0);
            Assert.AreEqual(6.456, myEllipse.Center.Y, 0);
            Assert.AreEqual(5, myEllipse.horizontalRadius, 0);
            Assert.AreEqual(6, myEllipse.verticalRadius, 0);

            myEllipse.Move(-0.123, -0.456);
            Assert.AreEqual(4, myEllipse.Center.X, 0);
            Assert.AreEqual(6, myEllipse.Center.Y, 0);
            Assert.AreEqual(5, myEllipse.horizontalRadius, 0);
            Assert.AreEqual(6, myEllipse.verticalRadius, 0);

            myEllipse.Move(-12, -26);
            Assert.AreEqual(-8, myEllipse.Center.X, 0);
            Assert.AreEqual(-20, myEllipse.Center.Y, 0);
            Assert.AreEqual(5, myEllipse.horizontalRadius, 0);
            Assert.AreEqual(6, myEllipse.verticalRadius, 0);

            try
            {
                myEllipse.Move(double.PositiveInfinity, 1);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-x value", e.Message);
            }

            try
            {
                myEllipse.Move(double.NegativeInfinity, 1);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-x value", e.Message);
            }

            try
            {
                myEllipse.Move(double.NaN, 1);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-x value", e.Message);
            }

            try
            {
                myEllipse.Move(1, double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-y value", e.Message);
            }

            try
            {
                myEllipse.Move(1, double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-y value", e.Message);
            }

            try
            {
                myEllipse.Move(1, double.NaN);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-y value", e.Message);
            }
        }

        [TestMethod]
        public void TestCaluculateArea()
        {
            Ellipse myEllipse = new Ellipse(1, 2, 5, 6);
            Assert.AreEqual(94.25, myEllipse.CalculateArea(), 1);
        }
    }
}
