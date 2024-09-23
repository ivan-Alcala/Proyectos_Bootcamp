namespace Figuras2D.Class
{
    public class Circle : Ellipse
    {
        public double Radius { get; set; }

        public Circle(string name, double radius)
            : base(name, radius, radius) // En un círculo, majorAxis = minorAxis = radius
        {
            Radius = radius;
        }

        // Método abstracto para calcular el área ya está en la clase base
    }
}
