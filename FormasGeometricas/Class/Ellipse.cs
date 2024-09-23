using Figuras2D.Class;
using System;

public class Ellipse : Shape2D
{
    public double MajorAxis { get; set; }
    public double MinorAxis { get; set; }

    public Ellipse(string name, double majorAxis, double minorAxis) : base(name)
    {
        MajorAxis = majorAxis;
        MinorAxis = minorAxis;
    }

    public override double CalculateArea()
    {
        return Math.PI * MajorAxis * MinorAxis;
    }
}