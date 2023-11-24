using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Lab3_PonomarevaFO
{
    public class TypeTriangle2
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public int Ax { get; set; }
        public int Ay { get; set; }
        public int Bx { get; set; }
        public int By { get; set; }
        public int Cx { get; set; }
        public int Cy { get; set; }
        public static (string, List<(int, int)>) CalculateTriangleType(double sideA, double sideB, double sideC, float a, float b, float c, int Ax, int Ay, int Bx, int By, int Cx, int Cy)
        {
            if (a == b && b == c)
            {
                // Равносторонний треугольник
                string triangleType = "Равносторонний";
                List<(int, int)> coordinates = new List<(int, int)> { (Ax, Ay), (Bx, By), (Cx, Cy) };
                return (triangleType, coordinates);
            }
            else if (a == b || a == c || b == c)
            {
                // Равнобедренный треугольник
                string triangleType = "Равнобедренный";
                List<(int, int)> coordinates = new List<(int, int)> { (Ax, Ay), (Bx, By), (Cx, Cy) };
                return (triangleType, coordinates);
            }
            else
            {
                // Разносторонний треугольник
                string triangleType = "Разносторонний";
                return (triangleType, null);
            }
        }
    }
}
