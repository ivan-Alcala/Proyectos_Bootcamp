using System;

namespace Figuras2D.Class
{
    public class Cube : Shape3D
    {
        public double Edge { get; set; }

        public Cube(double edge)
            : base()
        {
            Edge = edge;
        }

        public override double CalculateArea()
        {
            return 6 * Edge * Edge;
        }

        public override double CalculateVolume()
        {
            return Math.Pow(Edge, 3);
        }

        public override string ToString()
        {
            return $"{GetType().Name} - Área: {CalculateArea()} - Volumen: {CalculateVolume()}";
        }
    }
}