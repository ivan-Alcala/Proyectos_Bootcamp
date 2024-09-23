namespace Figuras2D.Class
{
    public abstract class GeometricShape
    {
        public string Name { get; set; }

        public GeometricShape(string name)
        {
            Name = name;
        }

        // Método abstracto para calcular el área
        public abstract double CalculateArea();

        public override string ToString()
        {
            return $"{Name} - Área: {CalculateArea()}";
        }
    }
}
