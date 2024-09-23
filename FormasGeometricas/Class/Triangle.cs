namespace Figuras2D.Class
{
    public class Triangle : Polygon
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public Triangle(string name, double baseLength, double height)
            : base(name, 3) // Un triángulo tiene 3 lados
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
