namespace Figuras2D.Class
{
    public class Circle : Ellipse
    {
        public double Radius { get; set; }

        public Circle(double radius)
            : base(radius, radius) // En un círculo, majorAxis = minorAxis = radius
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return base.CalculateArea(); // Math.PI * Radius * Radius
        }

        // Método abstracto para calcular el área ya está en la clase base
    }
}
