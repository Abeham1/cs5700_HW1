using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shapes
{
    public class Triangle
    {
        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }
        public Point Point3 { get; private set; }

        public Line Line1 { get; private set; }
        public Line Line2 { get; private set; }
        public Line Line3 { get; private set; }
        /**
         * Constructor based on x-y locations
         * @param x1            X-location of first point
         * @param y1            Y-location of first point
         * @param x2            X-location of second point
         * @param y2            Y-location of second point
         * @param x3            X-location of third point
         * @param y3            Y-location of third point
         * @throws exception    LineValidate will ensure all three lines have a length > 0
        */
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Point1 = new Point(x1, y1);
            Point2 = new Point(x2, y2);
            Point3 = new Point(x3, y3);

            Line1 = new Line(x1, y1, x2, y2);
            Line2 = new Line(x2, y2, x3, y3);
            Line3 = new Line(x3, y3, x1, y1);

            ValidateTriangle();
        }

        /**
         *
         * @param point1            The first point -- must not be null
         * @param point2            The second point -- must not be null
         * @param point3            The third point -- must not be null
         * @throws ShapeException   Exception throw if any parameter is invalid
         * @throws ShapeException   Whenever a line is passed two of the same point. 
         */
        public Triangle(Point point1, Point point2, Point point3)
        {
            if (point1 == null || point2 == null || point3 == null)
                throw new ShapeException("Invalid point");
            Line1 = new Line(point1, point2);
            Line2 = new Line(point2, point3);
            Line3 = new Line(point3, point1);

            Point1 = point1;
            Point2 = point2;
            Point3 = point3;

            ValidateTriangle();
        }

        /**
         * Move a triangle
         *
         * @param deltaX            The delta x-location by which the triangle should be moved -- must be a valid double
         * @param deltaY            The delta y-location by which the triangle should be moved -- must be a valid double
         * @throws ShapeException   Exception throw if any parameter is invalid
         * @throws ShapeException   When a triangle is moved to have a length of zero
         */
        public void Move(double deltaX, double deltaY)
        {
            Line1.Move(deltaX, deltaY);
            Line2.Move(deltaX, deltaY);
            Line3.Move(deltaX, deltaY);
        }

        public double ComputeArea()
        {
            double area = Math.Abs((Line1.Point1.X * (Line1.Point2.Y - Line2.Point2.Y) + Line1.Point2.X * (Line2.Point2.Y - Line1.Point1.Y) + Line2.Point2.X * (Line1.Point1.Y - Line1.Point2.Y)) / (2));
            return area;
        }

        /*
         * Validator will check to ensure:
         * 1. The length of any edge does not exceed the sum of the other two
         * 2. The points that make up the line must not reside on the same line
         */
        public void ValidateTriangle()
        {
            if ((Line1.ComputeLength() > Line2.ComputeLength() + Line3.ComputeLength()) ||
                (Line2.ComputeLength() > Line1.ComputeLength() + Line3.ComputeLength()) ||
                (Line3.ComputeLength() > Line1.ComputeLength() + Line2.ComputeLength()))
                throw new ShapeException("Invalid triangle");
            if (Line1.ComputeSlope() == Line2.ComputeSlope() ||
               Line2.ComputeSlope() == Line3.ComputeSlope() ||
               Line3.ComputeSlope() == Line1.ComputeSlope())
                throw new ShapeException("Invalid Triangle");
        }
    }
}
