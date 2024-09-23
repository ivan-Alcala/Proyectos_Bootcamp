using System;

namespace Figuras2D.Class
{
    public class Cube : Shape3D
    {
        public double Edge { get; set; }

        public Cube(string name, double edge) : base(name)
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
    }
}
