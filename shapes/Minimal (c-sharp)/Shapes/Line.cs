using System;

namespace Shapes
{
    public class Line
    {
        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }

        /**
         * Constructor based on x-y Locations
         * @param x1                The x-location of first point -- must be a valid double.
         * @param y1                The y-location of first point -- must be a valid double.
         * @param x2                The x-location of second point -- must be a valid double.
         * @param y2                The y-location of second point -- must be a valid double.
         * @throws ShapeException   Exception throw if any parameter is invalid
         * @throws ShapeException   Whenever a line is passed two of the same point. 
         */
        public Line(double x1, double y1, double x2, double y2)
        {
            Point1 = new Point(x1, y1);
            Point2 = new Point(x2, y2);

            ValidateLine();
        }

        /**
         *
         * @param point1            The first point -- must not be null
         * @param point2            The second point -- must not b e null
         * @throws ShapeException   Exception throw if any parameter is invalid
         * @throws ShapeException   Whenever a line is passed two of the same point. 
         */
        public Line(Point point1, Point point2)
        {
            if (point1==null || point2==null)
                throw new ShapeException("Invalid point");

            Point1 = point1;
            Point2 = point2;

            ValidateLine();
        }

        /**
         * Move a line
         *
         * @param deltaX            The delta x-location by which the line should be moved -- must be a valid double
         * @param deltaY            The delta y-location by which the line should be moved -- must be a valid double
         * @throws ShapeException   Exception throw if any parameter is invalid
         * @throws ShapeException   When a line is moved to have a length of zero
         */
        public void Move(double deltaX, double deltaY)
        {
            Point1.Move(deltaX, deltaY);
            Point2.Move(deltaX, deltaY);
            ValidateLine();
        }

        /**
         * @return  The length of the line
         */
        public double ComputeLength()
        {
            return Math.Sqrt(Math.Pow(Point2.X - Point1.X, 2) +
                             Math.Pow(Point2.Y - Point1.Y, 2));
        }

        /**
         * @return  The slope of the line
         */
        public double ComputeSlope()
        {
            return (Point2.Y - Point1.Y) / (Point2.X - Point1.X);
        }
        /*
         * @ Makes sure that the line does not have a length of zero 
         */
        public void ValidateLine()
        {
            if (this.Point1.X == this.Point2.X && this.Point1.Y == this.Point2.Y)
                throw new ShapeException("Line cannot have length of zero");
        }
    }
}
