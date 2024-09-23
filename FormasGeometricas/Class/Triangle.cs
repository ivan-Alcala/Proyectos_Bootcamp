namespace Figuras2D.Class
{
    public class Triangle : Polygon
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height)
            : base(3) // Un triángulo tiene 3 lados
        {
            BaseLength = baseLength;
            Height = height;
        }

        public override double CalculateArea()
        {
            return (BaseLength * Height) / 2;
        }
    }
}
