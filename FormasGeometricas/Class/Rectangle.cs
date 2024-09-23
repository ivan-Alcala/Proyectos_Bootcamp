namespace Figuras2D.Class
{
    public class Rectangle : Polygon
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public Rectangle(string name, double baseLength, double height)
            : base(name, 4) // Un rectángulo tiene 4 lados
        {
            BaseLength = baseLength;
            Height = height;
        }

        public override double CalculateArea()
        {
            return BaseLength * Height;
        }
    }
}
