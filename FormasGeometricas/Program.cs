using Figuras2D.Class;
using FormasGeometricas.Class;
using System;

namespace Figuras2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear formas 2D
            Circle circle = new Circle(5);
            Ellipse ellipse = new Ellipse(6, 4);
            Rectangle rectangle = new Rectangle(4, 6);
            Square square = new Square(5);
            Triangle triangle = new Triangle(3, 4);

            // Crear diagrama y añadir formas
            Diagram diagram = new Diagram();
            diagram.AddShape(circle);
            diagram.AddShape(ellipse);
            diagram.AddShape(rectangle);
            diagram.AddShape(square);
            diagram.AddShape(triangle);

            Console.WriteLine("Formas en el Diagrama:");
            diagram.DisplayShapes();
            Console.WriteLine($"Área Total del Diagrama: {diagram.CalculateTotalArea()}");

            Console.WriteLine("\n---------------------------\n");

            // Crear formas 3D
            Sphere sphere = new Sphere(3);
            Cube cube = new Cube(2);
            Pyramid pyramid = new Pyramid(4, 5);

            // Mostrar áreas y volúmenes de formas 3D
            Console.WriteLine("Formas 3D:");
            Console.WriteLine(sphere);
            Console.WriteLine(cube);
            Console.WriteLine(pyramid);

            Console.WriteLine("\n---------------------------\n");

            // Crear una malla compuesta por varias formas
            Mesh mesh = new Mesh();
            mesh.AddShape(circle);
            mesh.AddShape(rectangle);
            mesh.AddShape(sphere); // También puede incluir formas 3D si se desea
            mesh.AddShape(square);  // Añadimos un cuadrado a la malla

            Console.WriteLine(mesh);

            Console.Write("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}