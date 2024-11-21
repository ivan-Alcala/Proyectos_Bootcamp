using System;

namespace Figuras2D.Class
{
    public class Sphere : Shape3D
    {
        public double Radius { get; set; }

        public Sphere(string name, double radius) : base(name)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return 4 * Math.PI * Radius * Radius;
        }

        public override double CalculateVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
        }
    }
}
