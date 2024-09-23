using Figuras2D.Class;

namespace FormasGeometricas.Class
{
    public class Square : Rectangle
    {
        public double SideLength { get; set; }

        public Square(string name, double sideLength)
            : base(name, sideLength, sideLength) // En un cuadrado, baseLength = height = sideLength
        {
            SideLength = sideLength;
        }

        // Método abstracto para calcular el área ya está en la clase base
    }
}
