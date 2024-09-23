using Figuras2D.Class;
using System;

namespace Figuras2D
{
    public class Pyramid : Shape3D
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public Pyramid(string name, double baseLength, double height)
            : base(name)
        {
            BaseLength = baseLength;
            Height = height;
        }

        public override double CalculateArea()
        {
            // Área superficial de una pirámide cuadrangular
            double apothem = Math.Sqrt(Math.Pow(BaseLength / 2, 2) + Height * Height);
            return BaseLength * BaseLength + 2 * BaseLength * apothem;
        }

        public override double CalculateVolume()
        {
            return (BaseLength * BaseLength * Height) / 3;
        }
    }
}
