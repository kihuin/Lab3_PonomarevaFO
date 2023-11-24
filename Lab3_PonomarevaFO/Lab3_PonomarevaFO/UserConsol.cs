using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_PonomarevaFO
{
    public interface IUserInterface
    {
        void GetUserInput();
    }

    public class ConsoleUserInterface : IUserInterface
    {
        public void GetUserInput()
        {
            Console.WriteLine("Введите стороны треугольника:");
            double sideA = Convert.ToDouble(Console.ReadLine());
            double sideB = Convert.ToDouble(Console.ReadLine());
            double sideC = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите координаты вершин треугольника:");
            int Ax = Convert.ToInt32(Console.ReadLine());
            int Ay = Convert.ToInt32(Console.ReadLine());
            int Bx = Convert.ToInt32(Console.ReadLine());
            int By = Convert.ToInt32(Console.ReadLine());
            int Cx = Convert.ToInt32(Console.ReadLine());
            int Cy = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите значения a, b, c:");
            float a = Convert.ToSingle(Console.ReadLine());
            float b = Convert.ToSingle(Console.ReadLine());
            float c = Convert.ToSingle(Console.ReadLine());

            (string triangleType, List<(int, int)> coordinates) result = TypeTriangle2.CalculateTriangleType(sideA, sideB, sideC, a, b, c, Ax, Ay, Bx, By, Cx, Cy);

            Console.WriteLine(result.triangleType);
            if (result.coordinates != null)
            {
                Console.WriteLine("Координаты вершин треугольника:");
                foreach (var coordinate in result.coordinates)
                {
                    Console.WriteLine($"({coordinate.Item1}, {coordinate.Item2})");
                }
            }
        }
    }
}
