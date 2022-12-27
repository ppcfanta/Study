using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите свое имя: ");
            string userName = Console.ReadLine();
            if (userName=="") userName="Пользователь";

            Console.WriteLine($"Привет, {userName}, сегодня {DateTime.Today.ToShortDateString()}");
        }
    }
}
