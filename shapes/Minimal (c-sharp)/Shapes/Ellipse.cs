using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Ellipse
    {
        public Point Center { get; protected set; }
        public Point Foci1 { get; private set; }
        public Point Foci2 { get; private set; }
        public double verticalRadius { get; protected set; }
        public double horizontalRadius { get; protected set; }

        /**
         * Constructor with x-y Location for center
         *
         * @param x                 The x-location of the center of the circle -- must be a valid double
         * @param y                 The y-location of the center of the circle
         * @param horizontalRad     The horizontal radius of the circle -- must be greater or equal to zero.
         * @param verticalRad       The vertical radius of the circle -- must be greater or equal to zero.
         * @throws ShapeException   The exception thrown if the x, y, or z are not valid
         */
        public Ellipse(double x1, double y1, double horizontalRad, double verticalRad)
        {
            if (Math.PI * verticalRad * horizontalRad == 0)
                throw new ShapeException("Invalid Ellipse");

            Center = new Point(x1, y1);
            Validator.ValidatePositiveDouble(horizontalRad, "Invalid radius");
            Validator.ValidatePositiveDouble(verticalRad, "Invalid radius");
            verticalRadius = verticalRad;
            horizontalRadius = horizontalRad;
        }

        /**
         * Constructor with a Point for center
         *
         * @param center            The x-location of the center of the circle -- must be a valid point
         * @param verticalRad       The vertical radius of the ellipse -- must be greater or equal to zero.
         * @param horizontalRad     The horizontal radius of the ellipse -- must be greater or equal to zero.
         * @throws ShapeException   The exception thrown if the x, y, or z are not valid
         */
        public Ellipse(Point center, double horizontalRad, double verticalRad)
        {
            Validator.ValidatePositiveDouble(horizontalRad, "Invalid radius");
            Validator.ValidatePositiveDouble(verticalRad, "Invalid radius");
            if (center == null)
                throw new ShapeException("Invalid center point");

            Center = center;
            horizontalRadius = horizontalRad;
            verticalRadius = verticalRad;
        }

        /*
         * performs simple area calculation
         */
        public double CalculateArea()
        {
            return (Math.PI * verticalRadius * horizontalRadius);
        }

        /**
         * Move the ellipse
         * @param deltaX            a delta change for the x-location of center of the circle
         * @param deltaY            a delta change for the y-location of center of the circle
         * @throws ShapeException   Exception thrown if either the delta x or y are not valid doubles
         */
        public void Move(double deltaX, double deltaY)
        {
            Center.Move(deltaX, deltaY);
        }
    }
}
