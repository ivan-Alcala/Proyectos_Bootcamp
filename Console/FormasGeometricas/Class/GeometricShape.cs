namespace Figuras2D.Class
{
    public abstract class GeometricShape
    {
        public GeometricShape() { }

        // Método abstracto para calcular el área
        public abstract double CalculateArea();

        public override string ToString()
        {
            return $"{GetType().Name} - Área: {CalculateArea()}";
        }
    }
}
