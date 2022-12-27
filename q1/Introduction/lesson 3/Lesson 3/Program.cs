using System;

namespace Lesson_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Task19();
            Task21();
            Task23();
        }

        private static void Task19()
        {
            Console.WriteLine("\nЗадача 19");
            Console.Write("\nВведите 5-тизначное число: ");
            string number = Console.ReadLine();

            if (number.Length == 5)
            {
                if (number[0] == number[4] && number[1] == number[3]) Console.WriteLine($"Число {number} палиндром");
                else Console.WriteLine($"Число {number} не палиндром");
            }
            else Console.WriteLine($"Число {number} не пятизначное!");
        }

        private static void Task21()
        {
            Console.WriteLine("\nЗадача 21");
            
            Console.Write("\nВведите x1: ");
            var x1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите y1: ");
            var y1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите z1: ");
            var z1 = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("\nВведите x2: ");
            var x2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите y2: ");
            var y2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите z2: ");
            var z2 = Convert.ToInt32(Console.ReadLine());

            var x = x2 - x1;
            var y = y2 - y1;
            var z = z1 - z2;

            var length = Math.Sqrt(x * x + y * y + z * z);
            Console.WriteLine($"\nРасстояние между точками равно: {length}");
        }

        private static void Task23()
        {
            Console.WriteLine("\nЗадача 23");
            Console.Write("\nВведите число N: ");
            var number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Таблица кубов чисел от 1 до {number}: ");
            for (var i = 1; i <= number; i++)
            { 
                Console.Write($"{i}\t");
            }
            Console.WriteLine();
            for (var i = 1; i <= number; i++)
            { 
                Console.Write($"{i*i*i}\t");
            }
        }
        
    }
}