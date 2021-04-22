using System;
using System.Threading.Channels;


namespace Lesson2
{
    class Program
    {
        static void Main()
        {
            //****************** Задание 1 ***********************
            Console.WriteLine("Задание 1. Реализовать двусвязанный список.");
            var nodes = new NodeList();
            nodes.AddNode(45);
            nodes.AddNode(5);
            nodes.AddNode(12);
            nodes.AddNode(88);
            //Console.WriteLine(nodes.FindNode(12).Value);
            Console.WriteLine("Изначальный список:");
            nodes.PrintNodeList();

            Console.WriteLine("\nДобавляем элемент(77) после 12 , выводим список:");
            nodes.AddNodeAfter(nodes.GetNodeByIndex(2), 77);
            nodes.PrintNodeList();

            Console.WriteLine("\nДобавляем новый элемент(значение=99) в конец списка, выводим список:");
            nodes.AddNode(99);
            nodes.PrintNodeList();

            Console.WriteLine("\nУдаляем элемент с порядковым номером 2, выводим список:");
            nodes.RemoveNode(1);
            nodes.PrintNodeList();

            //****************** Задание 2 ***********************
            Console.WriteLine("\n\nЗадание 2. Реализовать бинарный поиск.");
            var myArray = new IntArray();
            Console.WriteLine("\nСоздаем и заполняем массив данными:");
            myArray.FillArray();
            myArray.Print();
            Console.WriteLine("\nСортируем массив:");
            myArray.Sort();
            myArray.Print();
            Console.Write("\nВведите элемен для поиска: ");
            int.TryParse(Console.ReadLine(), out int numToSearch);
            int index = myArray.BinarySearch(numToSearch);
            Console.WriteLine("\nДанный элемент " + ((index == -1) ? "не найден" : $"найден по индексу: {index}"));

            //////////////////////////////////////////
            // Асимптотическая сложность равна log2 N
            //////////////////////////////////////////
        }
    }
}
