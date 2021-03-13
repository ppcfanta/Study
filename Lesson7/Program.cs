using System;

namespace Lesson7
{
    class Program
    {
        const char USER_DOT = 'x';
        const char AI_DOT = 'o';
        const int FIELD_SIZE = 3;
        static char[,] _field = new char[FIELD_SIZE, FIELD_SIZE];
        private static bool _gameOver;

        static void Main()
        {
            //Lottrey();

            Cross();
        }

        private static void Cross()
        {
            InitField();
            DrawField();

            do
            {
                PlayerTurn();
                DrawField();
                CheckVictory();
                AITurn();
                DrawField();
                CheckVictory();
            } while (!_gameOver);

        }

        private static void CheckVictory()
        {
            //throw new NotImplementedException();
        }

        private static void AITurn()
        {
            do
            {
                int x = new Random().Next(1, FIELD_SIZE);
                int y = new Random().Next(1, FIELD_SIZE);
                //if (_field[y-1, x-1] == '.')
                {
                    _field[y-1, x-1] = AI_DOT;
                    break;
                }
            } while (true);
            
            

        }

        private static void PlayerTurn()
        {
            
            do
            {
                int y = GetIntFromConsole("Введите строку:", 1, FIELD_SIZE);
                int x = GetIntFromConsole("Введите столбец:", 1, FIELD_SIZE);

                if (_field[y - 1, x - 1]=='.')
                {
                    _field[y - 1, x - 1] = USER_DOT;
                    break;
                }

                Console.WriteLine("Ячейка занята, выберите другую!");
            } while (true);
            
        }

        private static void DrawField()
        {
            Console.Clear();
            for (int i = 0; i < _field.GetLength(1); i++)
            {
                Console.Write("|");
                for (int j = 0; j < _field.GetLength(0); j++)
                {
                    Console.Write(_field[i,j]+"|");
                }
                Console.WriteLine("");
            }
        }

        private static void InitField()
        {
            for (int i = 0; i < _field.GetLength(1); i++)
            {
                for (int j = 0; j < _field.GetLength(0); j++)
                {
                    _field[i, j] = '.';
                }
            }
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
