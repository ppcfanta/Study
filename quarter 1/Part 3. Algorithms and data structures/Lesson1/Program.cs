using System;

namespace Lesson1
{
    class Program
    {
        static void Main()
        {
            
            //**************** Task 1 *****************
            int number;
            do
            {
                Console.Write("Ведите целое положительное число: ");
                int.TryParse(Console.ReadLine(), out number);
            } while (number<=0);
            
            Console.WriteLine(Calculator.IsNumberSimple(number) ? "Число простое!" : "Число не простое!");

            //**************** Task 2 *****************
            // Итоговая сложность StrangeSum - N*N*N, то есть N^3.
            // Сложность отдельных операций - в комментариях функции

            //**************** Task 3 *****************
            int fiboNum;
            do
            {
                Console.Write("Введите номер числа Фибоначчи: ");
                int.TryParse(Console.ReadLine(), out fiboNum);
            } while (fiboNum <= 0);

            Console.WriteLine("Число Фибо через рекурсию: " + Calculator.CalcFiboRecursive(fiboNum));
            Console.WriteLine("Число Фибо через цикл: " + Calculator.CalcFibo(fiboNum));

        }


        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;    // O(1)
            for (int i = 0; i < inputArray.Length; i++)             // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++)         // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++)     // O(N)
                    {
                        int y = 0;          // O(1)
                        if (j != 0)         // O(1)
                        {
                            y = k / j;      // O(1)
                        }
                        sum += inputArray[i] + i + k + j + y;       // O(1)
                    }
                }
            }
            return sum;     // O(1)
        }
    }
    public static class Calculator
    {
        public static bool IsNumberSimple(int number)
        {
            if (number <= 2) return true;     // если ввели 1 или 2

            for (int i = 3; i < Math.Abs(number); i += 2)     // бежим только по нечетным
            {
                if (number % i == 0)
                    return false;       // если встретили первый делитель, нет необходимости продолжать, число уже не простое
            }

            return true;    // прошли цикл без выходов, значит делитель не найден, число простое
        }

        public static long CalcFiboRecursive(int num)
        {
            if (num == 0 || num == 1)
                return num;
            return CalcFiboRecursive(num - 1) + CalcFiboRecursive(num - 2);
        }

        public static long CalcFibo(int num)
        {
            int fibo_sum, i = 0, fibo1 = 1, fibo2 = 1;
            while (i < num-2)
            {
                fibo_sum = fibo1 + fibo2;
                fibo1 = fibo2;
                fibo2 = fibo_sum;
                i = i + 1;
            }

            return fibo2;
        }
    }
}
