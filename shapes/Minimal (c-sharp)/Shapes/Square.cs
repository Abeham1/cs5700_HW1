using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Square
    {
        public Line Line1 { get; private set; }
        public Line Line2 { get; private set; }
        public Line Line3 { get; private set; }
        public Line Line4 { get; private set; }

        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }
        public Point Point3 { get; private set; }
        public Point Point4 { get; private set; }
        public double height { get; private set; }
        public double width { get; private set; }


        /**
         * Constructor based on x-y locations
         * @param x1            X-location of first point
         * @param y1            Y-location of first point
         * @param x2            X-location of second point
         * @param y2            Y-location of second point
         * @param x3            X-location of third point
         * @param y3            Y-location of third point
         * @param x4            X-location of fourth point
         * @param y4            Y-location of fourth point
         * @throws exception    LineValidate will ensure all three lines have a length > 0
        */
        public Square(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            Line1 = new Line(x1, y1, x2, y2);
            Line2 = new Line(x2, y2, x3, y3);
            Line3 = new Line(x3, y3, x4, y4);
            Line4 = new Line(x4, y4, x1, y1);

            Point1 = new Point(x1, y1);
            Point2 = new Point(x2, y2);
            Point3 = new Point(x3, y3);
            Point4 = new Point(x4, y4);

            height = Line1.ComputeLength();
            width = Line1.ComputeLength();

            ValidateSquare();
        }

        /**
         *
         * @param point1            The first point -- must not be null
         * @param point2            The second point -- must not be null
         * @param point3            The third point -- must not be null
         * @param point4            The fourth point -- must not be null
         * @throws ShapeException   Exception throw if any parameter is invalid
         * @throws ShapeException   Whenever a line is passed two of the same point. 
         */
        public Square(Point point1, Point point2, Point point3, Point point4)
        {
            if (point1 == null || point2 == null || point3 == null || point4 == null)
                throw new ShapeException("Invalid point");
            Line1 = new Line(point1, point2);
            Line2 = new Line(point2, point3);
            Line3 = new Line(point3, point4);
            Line4 = new Line(point4, point1);

            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
            Point4 = point4;

            height = Line2.ComputeLength();
            width = Line1.ComputeLength();

            ValidateSquare();
        }

        /**
         * Move a rectangle
         *
         * @param deltaX            The delta x-location by which the rectangle should be moved -- must be a valid double
         * @param deltaY            The delta y-location by which the rectangle should be moved -- must be a valid double
         * @throws ShapeException   Exception throw if any parameter is invalid
         * @throws ShapeException   When a rectangle is moved to have a length of zero
         */
        public void Move(double deltaX, double deltaY)
        {
            Line1.Move(deltaX, deltaY);
            Line2.Move(deltaX, deltaY);
            Line3.Move(deltaX, deltaY);
            Line4.Move(deltaX, deltaY);
        }

        public double ComputeArea()
        {
            double area = Math.Pow(Line1.ComputeLength(), 2);
            return area;
        }

        /*
         * ValidateSquare ensures that all vertecies have an angle of 90
         */
        public void ValidateSquare()
        {
            var LineAC = new Line(Line1.Point1, Line2.Point2);
            if (
                (Math.Acos((Math.Pow(Line1.ComputeLength(), 2) + Math.Pow(Line4.ComputeLength(), 2) - Math.Pow(LineAC.ComputeLength(), 2) / (2 * Line1.ComputeLength() * Line4.ComputeLength())))) != 90
                )
                throw new ShapeException("Invalid rectangle");
        }
    }
}