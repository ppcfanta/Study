using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Lesson2
{
    class Program
    {
        /// <summary>
        /// Метод запрашивает ввод целого числа с клавиатуры.
        /// </summary>
        /// <param name="message">Приветствие для ввода</param>
        /// <param name="onlyPositive">Ожидать только положительные числа?</param>
        /// <returns>Парсит ввод и возвращает число int</returns>
        static int InputIntFromConsole(string message, bool onlyPositive = false)
        {
            int result;
            bool isParseSeccessfull;
            do
            {
                Console.Write(message + " ");
                isParseSeccessfull = int.TryParse(Console.ReadLine(), out result);
                if (!isParseSeccessfull)   // если парсинг прошел неудачно - пишем ошибку и повторяем цикл(ввод)
                {
                    Console.WriteLine("Вы ввели не целое число. Повторите ввод.");
                    continue;
                }

                if (onlyPositive && (result < 0)) //если ожидается положительное число, а ввели отрицательное - выдаем ошибку и повторяем цикл
                {
                    Console.WriteLine("Вы ввели отрицательное число, а ожидается положительное.");
                    isParseSeccessfull = false;   //принудительно ставим false, даже если парсинг прошел удачно
                    continue;
                }
                break;   // если все хорошо (т.е. не сработал ни один вышестоящий if) - выходим из цикла
            } while (!isParseSeccessfull);
            return result;
        }

        /// <summary>
        /// Метод запрашивает мин и макс температуры, считает среднесуточную температуру.
        /// </summary>
        /// <returns>Средняя температура</returns>
        static double GetAverageTemp()
        {
            int minTemp, maxTemp;
            minTemp = InputIntFromConsole("Введите минимальную суточную температуру:");
            maxTemp = minTemp - 1;  // специально устанавливаем максимальную температуру меньше минимальной
            
            while (minTemp > maxTemp)
            {
                maxTemp = InputIntFromConsole("Введите максимальную суточную температуру:");
                if (maxTemp < minTemp) Console.WriteLine("Максимальная температура не может быть меньше минимальной. Повторите ввод.");
            }
            return (double)(minTemp + maxTemp) / 2;
        }

        public enum MonthOfYear
        {
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }

        /// <summary>
        /// Метод выводит название месяца по его номеру
        /// </summary>
        /// <returns>Название месяца</returns>
        public static MonthOfYear GetMonthNumber()
        {
            int monthNumber = -1;
            bool correctMonthNumber;
            do
            { 
                monthNumber = InputIntFromConsole("Введите номер месяца:", true);
                correctMonthNumber = (monthNumber >= 1) && (monthNumber <= 12);
                if(correctMonthNumber) break;       // Ввели правильный номер месяца - выходим из цикла
                Console.WriteLine("Вы ввели неправильный номер месяца");              // иначе пишем ошибку и повторяем цикл
            } while (!correctMonthNumber);

            return (MonthOfYear)monthNumber;
        }

        /// <summary>
        /// Метод распечатывает чек на экран
        /// </summary>
        public static void PrintReceipt()
        {
            string orgName = "ООО \"Рога и копыта\"", 
                   productCode = "3005-4904", productModel = "SM-G991B", productName = "Смартфон Samsung Galaxy \nS21 Ultra 5G 256 ГБ серебристый фантом", 
                   serviceCenterAddr = "Москва, Варшавское шоссе, дом 26", serviceCenterPhone = "+7 (499) 682-64-56",
                   serviceCenterWorkSchedule = "Понедельник-пятница: 10.00 до \n17.00; Суббота: с 10.00 до 14.00",
                   kkm = "22233444";
            int orgINN = 1234567890, orgKPP = 987654321, quantity = 1, price = 104_590, totalSum = quantity * price, admNumber = 1969;
            DateTime purchaseDate = new DateTime(2021, 2, 10, 12, 38, 00);

            Console.WriteLine("\n\t\tТоварный чек");
            Console.WriteLine(orgName);
            Console.WriteLine("ИНН "+orgINN+"\t КПП "+ orgKPP);
            Console.WriteLine("Спасибо за покупку!\n");
            Console.WriteLine(productCode+", "+ productModel+", "+ productName);
            Console.WriteLine("\t"+ quantity + " x "+ price + "р.................."+ totalSum + "р");
            Console.WriteLine("============================================\n");
            Console.WriteLine("Официальный сервисный центр Samsung. Адрес: \n" + serviceCenterAddr);
            Console.WriteLine("Контактный телефон: " + serviceCenterPhone);
            Console.WriteLine("График работы: " + serviceCenterWorkSchedule);
            Console.WriteLine("============================================");
            Console.WriteLine("\t\tИТОГО К ОПЛАТЕ......." + totalSum + "р");
            Console.WriteLine("============================================");
            Console.WriteLine("ККМ "+kkm + " ИНН "+ orgINN + " " + purchaseDate.ToShortDateString()+ " " + purchaseDate.ToShortTimeString());
            Console.WriteLine("Продажа\t\t      СИСТ. АДМИНИСТР. #" + admNumber);
            Console.WriteLine("ИТОГ\t\t\t\t     "+ totalSum+"р");
            Console.WriteLine("\n\n");
        }

        [Flags]
        public enum DayOfWeekOpened
        {
            Понедельник = 0b_0000001,
            Вторник     = 0b_0000010,
            Среда       = 0b_0000100,
            Четверг     = 0b_0001000,
            Пятница     = 0b_0010000,
            Суббота     = 0b_0100000,
            Воскресенье = 0b_1000000,
            //Рабочие_дни  = Понедельник | Вторник | Среда | Четверг | Пятница,   //можно прям тут группировать
            //Выходные_дни = Суббота | Воскресенье
        }

        public static void PrintOfficeSchedules()
        {
            DayOfWeekOpened office1OpenDays = DayOfWeekOpened.Вторник | DayOfWeekOpened.Среда | DayOfWeekOpened.Четверг | DayOfWeekOpened.Пятница;
            DayOfWeekOpened office2OpenDays = DayOfWeekOpened.Понедельник | DayOfWeekOpened.Вторник | DayOfWeekOpened.Среда | DayOfWeekOpened.Четверг | 
                                                DayOfWeekOpened.Пятница | DayOfWeekOpened.Суббота | DayOfWeekOpened.Воскресенье;
            DayOfWeekOpened office3OpenDays = office1OpenDays | DayOfWeekOpened.Понедельник;  // можно и так объединять

            //DayOfWeekOpened office4_open_days = DayOfWeekOpened.Рабочие_дни;
            //DayOfWeekOpened office5_open_days = DayOfWeekOpened.Выходные_дни;

            Console.WriteLine($"Дни работы Офиса1: {office1OpenDays}");
            Console.WriteLine($"Дни работы Офиса2: {office2OpenDays}");
            Console.WriteLine($"Дни работы Офиса3: {office3OpenDays}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1. Расчет средней температуры.");
            double avgTemp = GetAverageTemp();
            Console.WriteLine("Среднесуточная температура: " + avgTemp);

            Console.WriteLine("\nЗадание 2. Вывод названия месяца по номеру.");
            MonthOfYear monthNumber = GetMonthNumber();
            Console.WriteLine("Название введенного месяца: " + monthNumber);
            if ((monthNumber == MonthOfYear.Декабрь || monthNumber == MonthOfYear.Январь || monthNumber == MonthOfYear.Февраль) && avgTemp > 0) Console.WriteLine("Дождливая зима");

            Console.WriteLine("\nЗадание 3. Определить, является ли введённое пользователем число чётным.");
            Console.WriteLine("Введенное число " + (InputIntFromConsole("Введите число:") % 2 == 0 ? "чётное!" : "нечётное!"));

            Console.WriteLine("\nЗадание 4. Распечатка чека на экран. (Нажмите Enter)");
            Console.ReadKey();
            PrintReceipt();

            Console.WriteLine("\nЗадание 5. Вывод графика работы офисов. (Нажмите Enter)");
            Console.ReadKey();
            PrintOfficeSchedules();
        }
    }
}
