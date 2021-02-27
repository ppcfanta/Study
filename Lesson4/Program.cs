using System;

namespace Lesson4
{
    class Program
    {


        static void Main()
        {
            Console.WriteLine("Задание 1. Написать метод, принимающий на вход ФИО в разных аргументах и возвращающий строку с ФИО.\n");
            string fName1 = "Николай", lName1 = "Терентьев", patronymic1 = "Алексеевич", 
                   fName2 = "Анатолий", lName2 = "Иванов", patronymic2 = "Сергеевич",
                   fName3 = "Эдуард", lName3 = "Кузнецов", patronymic3 = "Иванович",
                   fName4 = "Михаил", lName4 = "Васильев", patronymic4 = "Андреевич";
            Console.WriteLine(GetFullName(fName1, lName1, patronymic1));
            Console.WriteLine(GetFullName(fName2, lName2, patronymic2));
            Console.WriteLine(GetFullName(fName3, lName3, patronymic3));
            Console.WriteLine(GetFullName(fName4, lName4, patronymic4));

            //Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке. 
            //Ввести данные с клавиатуры и вывести результат на экран.
            //Console.WriteLine("\nЗадание 2. Написать метод, принимающий набор чисел, разделенных пробелом, и возвращающий сумму всех чисел в строке.\n");
            //ParseAndSum();

            Console.WriteLine("\nЗадание 3. Написать метод по определению времени года.\n");
            PrintSeasonByMonthNum();
        }
        
        /// <summary>
        /// Метод принимает имя, фамилию, отчество и возвращает ФИО одной строкой
        /// </summary>
        /// <returns>ФИО одной строкой</returns>
        public static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return lastName + " " + firstName + " " + patronymic;
        }

        /// <summary>
        /// Метод парсит входящую строку в виде чисел, разделенных пробелами, складывает эти числа и сумму выводит на экран
        /// </summary>
        /// <param name="strOfNumbers"></param>
        public static void ParseAndSum()
        {
            string strOfNumbers;
            bool isStrOfNum;
            int sum=0;
            do
            {
                Console.WriteLine("Введите строку, в которой цифры и пробелы:");
                strOfNumbers = Console.ReadLine();
                isStrOfNum = IsStrOfNum(strOfNumbers);
                if (!isStrOfNum)  Console.WriteLine("Ошибка: строка содержит не только цифры/пробелы! Повторите ввод:");                
            } while (!isStrOfNum);

            if (strOfNumbers.Length == 0) Console.WriteLine("Строка пустая! Сумма чисел равна 0."); ; // если строка пустая - сразу выходим

            // запускаем рекурсивный механизм парсинга и суммирования
            sum += RecursiveParseAndSumNumber(strOfNumbers, 0);
            Console.WriteLine($"Сумма чисел равна {sum}");
        }

        /// <summary>
        /// Метод рекурсивно парсит строку и суммирует найденные в ней числа/цифры. Пробелы считаются разделителями.
        /// </summary>
        /// <param name="strOfNum"></param>
        /// <param name="nPos"></param>
        static int RecursiveParseAndSumNumber(string strOfNum, int nPos)
        {
            string parsedNumber = "";
            //int result;

            if (nPos >= strOfNum.Length) return 0;  // если позиция курсора дошла до конца массива(или по какой-то причине больше), возвращаем 0 и выходим

            for (; nPos < strOfNum.Length; nPos++)
            {
                if (strOfNum[nPos] == ' ')  // если пробел - перестаем парсить (обязательно переставив курсор на следующий символ)
                {
                    nPos++;
                    break;  
                }
                parsedNumber += strOfNum[nPos];  // если встретили цифру - записываем ее в итоговое число
            }

            int.TryParse(parsedNumber, out int result);
            // возвращаем сумму отпарсенного числа и результат рекурсивно вызванной функции со сдвигом курсора на следующую позицию после найденного числа
            return result + RecursiveParseAndSumNumber(strOfNum, nPos);              
        }

        /// <summary>
        /// Метод проверяет, состоит ли строка из цифр/пробелов
        /// </summary>
        /// <returns>True-если в строке только цифры/пробелы, иначе False</returns>
        static bool IsStrOfNum(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]) && !char.IsWhiteSpace(str[i])) return false;  // если встретили в строке не цифру и не пробел - возвращаем Flase                
            }
            return true;
        }

        /// <summary>
        /// Метод принимает от пользователя номер месяца и выводит время года, к которому относится этот месяц
        /// </summary>
        public static void PrintSeasonByMonthNum()
        {
            int monthNum;
            bool successParse;

            do
            {
                Console.Write("Введите номер месяца: ");
                successParse = int.TryParse(Console.ReadLine(), out monthNum);
                if (!successParse) Console.WriteLine("Неверный номер месяца!");  // если ввели не цифры
                else if (monthNum > 12 || monthNum < 1)     // если ввели не корректный номер месяца
                {
                    Console.WriteLine("Ошибка: введите число от 1 до 12");
                    successParse = false;
                }
            } while (!successParse);

            Console.Write("Время года: ");
            switch (monthNum)
            {
                case 12: case 1: case 2 :
                    Console.WriteLine(GetMonthNameByCode(SeasonsCode.Winter));
                    break;
                case 3: case 4: case 5 :
                    Console.WriteLine(GetMonthNameByCode(SeasonsCode.Spring));
                    break;
                case 6: case 7: case 8 :
                    Console.WriteLine(GetMonthNameByCode(SeasonsCode.Summer));
                    break;
                case 9: case 10: case 11 :
                    Console.WriteLine(GetMonthNameByCode(SeasonsCode.Autumn));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Метод выводит название времени года
        /// </summary>
        /// <param name="season">Код времени года</param>
        /// <returns>название времени года на руссом</returns>
        public static string GetMonthNameByCode(SeasonsCode season)
        {
            string result = season switch
            {
                SeasonsCode.Winter => "Зима",
                SeasonsCode.Spring => "Весна",
                SeasonsCode.Summer => "Лето",
                SeasonsCode.Autumn => "Осень",
                _ => "<неизвестное время года>",
            };
            return result;
        }

        /// <summary>
        /// Коды времен года
        /// </summary>
        public enum SeasonsCode
        {
            Winter, 
            Spring, 
            Summer, 
            Autumn
        }

    }


}
