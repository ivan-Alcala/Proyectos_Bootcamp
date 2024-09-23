using Figuras2D.Class;
using System;

namespace Figuras2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear formas 2D
            Circle circle = new Circle("Círculo A", 5);
            Rectangle rectangle = new Rectangle("Rectángulo A", 4, 6);
            Triangle triangle = new Triangle("Triángulo A", 3, 4);

            // Crear diagrama y añadir formas
            Diagram diagram = new Diagram();
            diagram.AddShape(circle);
            diagram.AddShape(rectangle);
            diagram.AddShape(triangle);

            Console.WriteLine("Formas en el Diagrama:");
            diagram.DisplayShapes();
            Console.WriteLine($"Área Total del Diagrama: {diagram.CalculateTotalArea()}");

            Console.WriteLine("\n---------------------------\n");

            // Crear formas 3D
            Sphere sphere = new Sphere("Esfera A", 3);
            Cube cube = new Cube("Cubo A", 2);
            Pyramid pyramid = new Pyramid("Pirámide A", 4, 5);

            // Mostrar áreas y volúmenes de formas 3D
            Console.WriteLine("Formas 3D:");
            Console.WriteLine($"{sphere.Name} - Área: {sphere.CalculateArea()} - Volumen: {sphere.CalculateVolume()}");
            Console.WriteLine($"{cube.Name} - Área: {cube.CalculateArea()} - Volumen: {cube.CalculateVolume()}");
            Console.WriteLine($"{pyramid.Name} - Área: {pyramid.CalculateArea()} - Volumen: {pyramid.CalculateVolume()}");

            Console.WriteLine("\n---------------------------\n");

            // Crear una malla compuesta por varias formas
            Mesh mesh = new Mesh("Malla A");
            mesh.AddShape(circle);
            mesh.AddShape(rectangle);
            mesh.AddShape(sphere);

            Console.WriteLine($"Malla: {mesh.Name} - Área Total: {mesh.CalculateArea()}");

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}