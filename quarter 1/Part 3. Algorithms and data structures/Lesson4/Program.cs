using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Lesson4
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Task 1. Протестируйте поиск строки в HashSet и в массиве
            SearchMeasurement();
            Console.WriteLine("\nДля запуска теста нажмите любую кнопку...");
            Console.ReadKey();
            BenchmarkRunner.Run<BenchTester>();
        }

        public static void SearchMeasurement()
        {
            const int SIZE = 500000;
            var strToSearch = "user195493";

            var strArray = new string[SIZE];
            FillArray(strArray, strArray.Length);

            var hashset = new HashSet<string>();
            FillHashSet(hashset, SIZE);

            Console.WriteLine($"Поиск строки в массиве из {SIZE} элементов...");
            var searchPos = SearchInArray(strArray, strToSearch);
            Console.WriteLine($"Строка {strToSearch} " + ((searchPos == -1) ? "не найдена" : $"присутствует в массиве (элемент №{searchPos})"));
            Console.WriteLine($"Поиск строки в массиве завершен за:");

            Console.WriteLine($"Строка {strToSearch} " + ((SearchInHashSet(hashset, strToSearch)) ? "присутствует в HashSet" : "отсутствует в HashSet"));
        }

        public static int SearchInArray(string[] array, string searchElement)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == searchElement)
                    return i;
            }

            return -1;
        }

        public static string[] FillArray(string[] array, int count)
        {
            for (int i = 0; i < count; i++)
                array[i] = "user" + (i+1);        // генерируем строки от "user1" до "user10000" с шагом 1
            return array;
        }

        public static bool SearchInHashSet(HashSet<string> hashset, string searchElement)
        {
            return hashset.Contains(searchElement);
        }

        public static HashSet<string> FillHashSet(HashSet<string> hashset, int count)
        {
            for (int i = 0; i < count; i++)
                hashset.Add("user" + (i + 1));        // заполняем от "user1" до "user10000" с шагом 1
            return hashset;
        }
    }
}
