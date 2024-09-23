namespace Figuras2D.Class
{
    public abstract class Shape3D : GeometricShape
    {
        public Shape3D(string name) : base(name) { }

        // Método abstracto para calcular el volumen
        public abstract double CalculateVolume();
    }
}
