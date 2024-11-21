using System;

namespace Figuras2D.Class
{
    public class Ellipse : Shape2D
    {
        public double MajorAxis { get; set; }
        public double MinorAxis { get; set; }

        public Ellipse(double majorAxis, double minorAxis)
            : base()
        {
            MajorAxis = majorAxis;
            MinorAxis = minorAxis;
        }

        public override double CalculateArea()
        {
            return Math.PI * MajorAxis * MinorAxis;
        }
    }
}