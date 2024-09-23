using System;
using System.Collections.Generic;

namespace Figuras2D.Class
{
    public class Diagram
    {
        public List<Shape2D> Shapes { get; set; }

        public Diagram()
        {
            Shapes = new List<Shape2D>();
        }

        public void AddShape(Shape2D shape)
        {
            Shapes.Add(shape);
        }

        public double CalculateTotalArea()
        {
            double totalArea = 0;
            foreach (var shape in Shapes)
                totalArea += shape.CalculateArea();

            return totalArea;
        }

        public void DisplayShapes()
        {
            foreach (var shape in Shapes)
                Console.WriteLine(shape);
        }
    }
}
