using Figuras2D.Class;

namespace FormasGeometricas.Class
{
    public class Square : Rectangle
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
            : base(sideLength, sideLength) // En un cuadrado, baseLength = height = sideLength
        {
            SideLength = sideLength;
        }

        public override double CalculateArea()
        {
            return base.CalculateArea(); // SideLength * SideLength
        }

        // Método abstracto para calcular el área ya está en la clase base
    }
}
