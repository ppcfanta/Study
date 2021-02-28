using System;
using System.IO;

namespace Lesson5
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine("Задание 1. Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.\n");
            //FromKeyboardToTextfile();

            //Console.WriteLine("Задание 2. Написать программу, которая при старте дописывает текущее время в файл «startup.txt».\n");
            //WriteTimestampToFile();

            Console.WriteLine("Задание 3. Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.\n");
            FromKeyboardToBinfile();

        }


        /// <summary>
        /// Запрашивает произвольный ввод с клавиатуры и выводит итоговые данные в текстовый файл
        /// </summary>
        static void FromKeyboardToTextfile()
        {            
            Console.WriteLine("Введите строку: ");
            string inputString = Console.ReadLine();

            string filename = "input_from_kbd.txt";

            Console.WriteLine($"Запись строки в файл \"{filename}\"...");
            try
            {                
                File.WriteAllText(filename, inputString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка записи в файл: "+e.Message);
            }
                        
            Console.WriteLine("Данные в файл записаны. Теперь считываем их и проверяем. Содержимое файла:");
            try
            {
                Console.WriteLine(File.ReadAllText(filename)); 
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка чтения из файла: " + e.Message);
            }
        }

        static void WriteTimestampToFile()
        {
            string filename = "startup.txt";


            Console.WriteLine($"Добавление текущего времени в файл \"{filename}\"...");
            try
            {
                File.AppendAllText(filename, $"Программа запущена. Время запуска: {DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}\n"); 
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка записи в файл: " + e.Message);
            }

            Console.WriteLine("Текущее содержимое файла:");
            try
            {
                Console.WriteLine(File.ReadAllText(filename));
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка чтения из файла: " + e.Message);
            }
        }
        
        /// <summary>
        /// Запрашивает произвольный набор чисел (0...255) с клавиатуры и выводит итоговые данные в бинарный файл
        /// </summary>
        static void FromKeyboardToBinfile()
        {
            byte[] writeArray = null;
            byte[] readArray = null;
            string filename = "input_from_kbd.bin";
            string inputString;
            string[] inputNums;

            Console.Write("Введите числа (0-255) через запятую: ");
            inputString = Console.ReadLine();
            inputNums = inputString.Split(',');         // Создаем массив строк, каждый элемент которой - веденное через запятую число с клавиатуры

            writeArray = new byte[inputNums.Length];    // Инициализируем массив байтов таким же количеством, сколько чисел введено с клавиатуры
                        
            try
            {
                for (int i = 0; i < writeArray.Length; i++) writeArray[i] = Convert.ToByte(inputNums[i]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка конвертации: "+ e.Message);
                return;
            }

            Console.WriteLine($"Запись введенных цифр в файл \"{filename}\"...");
            try
            {
                File.WriteAllBytes(filename, writeArray);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка записи в файл: " + e.Message);
            }

            Console.WriteLine("Читаем файл...");
            try
            {
                readArray = File.ReadAllBytes(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка чтения из файла: " + e.Message);
            }

            Console.WriteLine("Содержимое:");
            for (int i = 0; i < readArray.Length; i++) Console.Write(readArray[i]+ ((i<readArray.Length-1)?",":"\n\n"));
            
        }
    }
}
