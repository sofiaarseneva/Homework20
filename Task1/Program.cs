using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        delegate double MyDelegate(double r);
        static void Main(string[] args)
        {
            Console.WriteLine("Делегаты, лямбды и события!\n\n");
            try
            {
                Console.WriteLine("Введите радиус:");
                double r = Convert.ToDouble(Console.ReadLine());
                
                if (r <= 0)
                    throw new Exception("Введено некорректное значение радиуса!");

                MyDelegate myDelegate = GetCircleLenght;
                myDelegate += GetCircleSquare;
                myDelegate += GetVolume;
                
                Delegate[] methods = myDelegate.GetInvocationList();
                foreach (MyDelegate method in methods)
                {
                    double result = method(r);
                    switch (method.Method.Name)
                    {
                        case ("GetCircleLenght"):
                            Console.WriteLine($"\nДлина окружности равна {result}");
                            break;
                        case ("GetCircleSquare"):
                            Console.WriteLine($"Площадь круга равна {result}");
                            break;
                        case ("GetVolume"):
                            Console.WriteLine($"Объем шара равен {result}");
                            break;
                    }
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка!" + ex.Message);
                Console.ReadKey();
            }
        }
        static double GetCircleLenght(double radius) => 2 * Math.PI * radius;
        static double GetCircleSquare(double radius) => Math.PI * Math.Pow(radius, 2);
        static double GetVolume(double radius) => (double)4 / 3 * Math.PI * Math.Pow(radius, 3);
    }
}
