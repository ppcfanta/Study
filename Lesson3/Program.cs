using System;
using System.Dynamic;

namespace Lesson3
{
    class Program
    {
        /// <summary>
        /// Метод распечатывает элементы двумерного массива по диагонали.
        /// </summary>
        public static void PrintDMassDiagonal()
        {
            int[,] dMass =
                {
                    { 1, 0, 0, 0, 0, 0 },
                    { 0, 2, 0, 0, 0, 0 },
                    { 0, 0, 3, 0, 0, 0 },
                    { 0, 0, 0, 4, 0, 0 },
                    { 0, 0, 0, 0, 5, 0 },
                    { 0, 0, 0, 0, 0, 6 },
                };
            for (int x = 0; x < dMass.GetLength(0); x++)
            {
                for (int y = 0; y < dMass.GetLength(1); y++)  Console.Write($"{dMass[x, y]} ");
                Console.WriteLine();
            }
            
        }

        /// <summary>
        /// Метод запрашивает количество записей в телефонной книге, запрашивает данные по каждой записи и выводит книгу на экран
        /// </summary>
        public static void PhoneBook ()
        {
            string[,] phoneBook;
            int phoneEntries;
            Console.WriteLine("Сколько записей будет в телефонном справочнике? ");
            while(!int.TryParse(Console.ReadLine(), out phoneEntries));

            phoneBook = new string[phoneEntries, 2];

            for (int i = 0; i < phoneEntries; i++)
            {
                Console.Write($"Введите имя записи №{i+1}: ");
                phoneBook[i, 0] = Console.ReadLine();
                Console.Write($"Введите телефон/e-mail записи №{i+1}: "); ;
                phoneBook[i, 1] = Console.ReadLine();
            }

            Console.WriteLine("\nТелефонный справочник:");
            for (int i = 0; i <= phoneBook.GetUpperBound(0); i++)
            {
                Console.WriteLine($"Имя: {phoneBook[i, 0]}\t\tТелефон: {phoneBook[i, 1]}");
            }
        }

        /// <summary>
        /// Метод выводит строку, введенную пользователем, в обратном порядке
        /// </summary>
        public static void PrintReverseInput ()
        {
            Console.Write("Введите строку: ");
            string inputString = Console.ReadLine(), reverseString;
            char[] reverseArray = new char[inputString.Length];
            for (int i = inputString.Length-1, j=0; i >=0 ; i--, j++)   reverseArray[j] = inputString[i];   // заполняем массив char[] обратным перебором элементов начальной строки
            reverseString = new string(reverseArray);   // создаем строку из массива с инвертированными значениями 
            Console.WriteLine($"Инвертированная строка: "+ reverseString);
        }

        /// <summary>
        /// Метод запрашивает ввод элементов одномерного массива и число, 
        /// на которое нужно сдвинуть элементы (влево или вправо)
        /// </summary>
        public static void ArrayShift()
        {
            int[] oMass = { 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.Write("Исходный массив: ");
            for (int i = 0; i < oMass.Length; i++) Console.Write($"{oMass[i]} ");

            Console.Write("\nВведите сдвиг(положительный или отрицательный): ");
            int.TryParse(Console.ReadLine(), out int offset);       // вводим величину смещения
            offset %= oMass.Length;     //обрезаем ее кратно размеру массива (если число больше длины массива)

            for (int r = 0; r < Math.Abs(offset); r++)  // повторяем сдвиг offset раз
            {
                if (offset < 0)  // сдвиг влево
                {
                    int firstElement = oMass[0];        // Запоминаем первый элемент в буфер
                    for (int j = 0; j < oMass.Length - 1; j++) oMass[j] = oMass[j + 1];  //сдвигаем влево элементы с первого до предпоследнего
                    oMass[^1] = firstElement;  // в последний элемент вписываем значение первого                
                }
                else if (offset > 0)  // сдвиг вправо
                {
                    int lastElement = oMass[^1];
                    for (int k = oMass.Length - 1; k > 0; k--) oMass[k] = oMass[k - 1]; //сдвигаем элементы с последнего до второго
                    oMass[0] = lastElement;  // в первый элемент вписываем значение последнего
                }
            }
            Console.Write("Свинутый массив: ");
            for (int i = 0; i < oMass.Length; i++) Console.Write($"{oMass[i]} ");
        }

        /// <summary>
        /// Морской бой: вывод массива 10х10, где клетка Х-корабль, O - пустое место
        /// </summary>
        public static void SeaWar()
        {
            char[,] arr =               // статически заполняем массив. символ Х - это элемент корабля, символ пробел - пустое место на поле(для наглядности заполнения)
            {
                { 'X', ' ', 'X', 'X', 'X', 'X', ' ', 'X', 'X', 'X', },
                { ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', },
                { ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', 'X', 'X', },
                { ' ', ' ', ' ', 'X', 'X', 'X', ' ', ' ', ' ', ' ', },
                { 'X', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', },
                { ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', },
                { ' ', 'X', ' ', ' ', ' ', ' ', 'X', 'X', 'X', 'X', },
                { ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', },
                { ' ', 'X', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', },
                { ' ', ' ', ' ', 'X', ' ', 'X', 'X', ' ', 'X', ' ', }
            };

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write((arr[i,j] == ' '? 'O': 'X') +" ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1. Написать программу, выводящую элементы двумерного массива по диагонали.");
            PrintDMassDiagonal();

            Console.WriteLine("\nЗадание 2. Программа «Телефонный справочник».");
            PhoneBook();

            Console.WriteLine("\nЗадание 3. Вывод введённой пользователем строки в обратном порядке(olleH вместо Hello).");
            PrintReverseInput();

            Console.WriteLine("\nЗадание 4. Сдвиг массива.");
            ArrayShift();

            Console.WriteLine("\nЗадание 5. Морской бой: вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки");
            SeaWar();

        }
    }
}
