using System;

namespace Lesson7
{
    class Program
    {
        static void Main()
        {
            Lottrey();
        }

        private static void Lottrey()
        {
            var num = GetIntFromConsole("Введите число от 1 до 10:", 1, 10);
            int rnd = new Random().Next(1, 10);
            if (num == rnd)
            {
                Console.WriteLine($"==============================\nВыпало число {rnd}! Вы угадали! Получаете приз!\n==============================");
                return;
            }

            Console.WriteLine($"Увы. Вы не угадали, выпало число {rnd}.");
        }

        static int GetIntFromConsole(string message, int startValue = int.MinValue, int endValue = int.MaxValue)
        {
            int result;
            bool isParseSeccessfull;
            do
            {
                Console.Write($"{message} ");
                isParseSeccessfull = int.TryParse(Console.ReadLine(), out result);
                if (!isParseSeccessfull)   // если парсинг прошел неудачно - пишем ошибку и повторяем цикл(ввод)
                {
                    Console.WriteLine("Вы ввели не целое число. Повторите ввод.");
                    continue;
                }

                if ((result < startValue) || (result > endValue))
                {
                    Console.WriteLine("Введено неправильное число. Ожидается от {0} {1}", startValue, (endValue == int.MaxValue) ? "и выше" : "до " + endValue);
                    isParseSeccessfull = false;   //принудительно ставим false, даже если парсинг прошел удачно
                    continue;
                }
                break;   // если все хорошо (т.е. не сработал ни один вышестоящий if) - выходим из цикла
            } while (!isParseSeccessfull);
            return result;
        }
    }
}
