using System.Collections.Generic;

namespace Figuras2D.Class
{
    public class Mesh : GeometricShape
    {
        public List<GeometricShape> Shapes { get; set; }

        public Mesh(string name) : base(name)
        {
            Shapes = new List<GeometricShape>();
        }

        public void AddShape(GeometricShape shape)
        {
            Shapes.Add(shape);
        }

        public override double CalculateArea()
        {
            double totalArea = 0;
            foreach (var shape in Shapes)
                totalArea += shape.CalculateArea();

            return totalArea;
        }
    }
}
