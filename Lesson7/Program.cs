using System;
using System.Runtime.InteropServices;

namespace Lesson7
{
    class Program
    {
        const char USER_DOT = 'x';
        const char AI_DOT = 'o';
        const int FIELD_X_SIZE = 5;
        const int FIELD_Y_SIZE = 4;
        private const int DOT_TO_WIN = 3;
        static char[,] _field = new char[FIELD_Y_SIZE, FIELD_X_SIZE];
        private static bool _gameOver = false;
        private static char _whoWin = '.';

        static void Main()
        {
            // Задание 1. Тестирования процесса декомпиляции. Через dotPeek метод был декомпилирован, изменен и пересобран
            // После пересборки при вводе ЛЮБОГО числа выводилось сообщение "Вы выиграли!..."
            Lottrey();

            // Задание 2-3. Крестики-нолики
            Cross();
        }

        private static void Cross()
        {
            InitField();
            DrawField();

            do
            {
                PlayerTurn();
                if (_gameOver)
                    break;
                AITurn();
            } while (!_gameOver);

            var winner = "Ничья!";
            switch (_whoWin)        
            {
                case AI_DOT:
                    winner = "Выиграл AI!";
                    break;
                case USER_DOT:
                    winner = "Выиграл игрок!";
                    break;
            }
            Console.WriteLine($"Игра закончена! {winner}");
        }

        private static void CheckVictory()
        {
            CheckFullField();

            // Цикл по строкам, в каждой строке считаем количество указанных символов подряд
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                if (DotsInARow(i, AI_DOT) >= DOT_TO_WIN )
                {
                    _whoWin = AI_DOT;
                    _gameOver = true;
                    return;
                }

                if (DotsInARow(i, USER_DOT) >= DOT_TO_WIN)
                {
                    _whoWin = USER_DOT;
                    _gameOver = true;
                    return;
                }
            }

            // Цикл по столбцам, в каждом столбце считаем количество указанных символов подряд
            for (int j = 0; j < _field.GetLength(1); j++)
            {
                if (DotsInACol(j, AI_DOT) >= DOT_TO_WIN)
                {
                    _whoWin = AI_DOT;
                    _gameOver = true;
                    return;
                }

                if (DotsInACol(j, USER_DOT) >= DOT_TO_WIN)
                {
                    _whoWin = USER_DOT;
                    _gameOver = true;
                    return;
                }
            }

            // цикл по строкам для просчета нисходящей диагонали
            for (int row = 0; row <= _field.GetLength(0)-DOT_TO_WIN; row++)
            {
                if (DotsInDownDiagonal(row, 0, AI_DOT) >= DOT_TO_WIN)
                {
                    _whoWin = AI_DOT;
                    _gameOver = true;
                    return;
                }

                if (DotsInDownDiagonal(row, 0, USER_DOT) >= DOT_TO_WIN)
                {
                    _whoWin = USER_DOT;
                    _gameOver = true;
                    return;
                }
            }

            // цикл по столбцам для просчета нисходящей диагонали
            for (int col = 0; col <= _field.GetLength(1) - DOT_TO_WIN; col++)
            {
                if (DotsInDownDiagonal(0, col, AI_DOT) >= DOT_TO_WIN)
                {
                    _whoWin = AI_DOT;
                    _gameOver = true;
                    return;
                }

                if (DotsInDownDiagonal(0, col, USER_DOT) >= DOT_TO_WIN)
                {
                    _whoWin = USER_DOT;
                    _gameOver = true;
                    return;
                }
            }

            // цикл по строкам для просчета восходящей диагонали
            for (int row = _field.GetLength(0)-1; row >= DOT_TO_WIN-1; row--)
            {
                if (DotsInUpDiagonal(row, 0, AI_DOT) >= DOT_TO_WIN)
                {
                    _whoWin = AI_DOT;
                    _gameOver = true;
                    return;
                }

                if (DotsInUpDiagonal(row, 0, USER_DOT) >= DOT_TO_WIN)
                {
                    _whoWin = USER_DOT;
                    _gameOver = true;
                    return;
                }
            }

            // цикл по строкам для просчета восходящей диагонали
            for (int col = 0; col <= _field.GetLength(1) - DOT_TO_WIN; col++)
            {
                if (DotsInUpDiagonal(_field.GetLength(0)-1, col, AI_DOT) >= DOT_TO_WIN)
                {
                    _whoWin = AI_DOT;
                    _gameOver = true;
                    return;
                }

                if (DotsInUpDiagonal(_field.GetLength(0) - 1, col, USER_DOT) >= DOT_TO_WIN)
                {
                    _whoWin = USER_DOT;
                    _gameOver = true;
                    return;
                }
            }

        }

        /// <summary>
        /// Считает количество подряд идущих символов в строке
        /// </summary>
        /// <param name="row">Номер строки</param>
        /// <param name="dot">Символы, которые нужно посчитать</param>
        /// <returns>Количество подряд идущих символов в строке</returns>
        private static int DotsInARow(int row, char dot)
        {
            int result = 0, curSum = 0;
            char prevDot = '.';
            
            for (int col = 0; col < _field.GetLength(1); col++)
            {
                if (_field[row, col] == dot) // если текущий символ - тот который ищем, прибавляем счетчик
                {
                    curSum++;
                    if (col == _field.GetLength(1) - 1)  // если дошли до конца строки, записываем результат и выходим
                    {
                        result = curSum;
                        break;
                    }
                }
                else    // если встретили другой символ
                {
                    result = curSum > result ? curSum : result;  //  если текущая сумма больше ранее найденной - записываем ее как наибольшую
                    curSum = 0;
                }
                prevDot = dot;     // устанавливаем предыдущий символ
            }

            return result;
        }

        /// <summary>
        /// Считает количество подряд идущих символов в столбце
        /// </summary>
        /// <param name="col">Номер столбца</param>
        /// <param name="dot">Символы, которые нужно посчитать</param>
        /// <returns>Количество подряд идущих символов в столбце</returns>
        private static int DotsInACol(int col, char dot)
        {
            int result = 0, curSum = 0;
            char prevDot = '.';
            
            for (int row = 0; row < _field.GetLength(0); row++)
            {
                if (_field[row, col] == dot) // если текущий символ - тот который ищем, прибавляем счетчик
                {
                    curSum++;
                    if (row == _field.GetLength(0) - 1)  // если дошли до конца столбца, записываем результат и выходим
                    {
                        result = curSum;
                        break;
                    }
                }
                else    // если встретили другой символ
                {
                    result = curSum > result ? curSum : result;  //  если текущая сумма больше ранее найденной - записываем ее как наибольшую
                    curSum = 0;
                }

                prevDot = dot;     // устанавливаем предыдущий символ
            }

            return result;
        }

        /// <summary>
        /// Вычисляет количество подряд идущих точек по нисходящей диагонали
        /// </summary>
        /// <param name="row">строка элемента</param>
        /// <param name="col">столбец элемента</param>
        /// <param name="dot">символ</param>
        /// <returns></returns>
        private static int DotsInDownDiagonal(int row, int col, char dot)
        {
            int result = 0, curSum = 0;
            char prevDot = '.';
                while (row<_field.GetLength(0) && col < _field.GetLength(1))
            {
                if (_field[row, col] == dot) // если текущий символ - тот который ищем, прибавляем счетчик
                {
                    curSum++;
                    if (row == _field.GetLength(0) - 1 || col == _field.GetLength(1) - 1)  // если дошли до конца столбца, записываем результат и выходим
                    {
                        result = curSum;
                        break;
                    }
                }
                else    // если встретили другой символ
                {
                    result = curSum > result ? curSum : result;  //  если текущая сумма больше ранее найденной - записываем ее как наибольшую
                    curSum = 0;
                }

                row++;
                col++;
                prevDot = dot;
            }
            return result;
        }


        /// <summary>
        /// Вычисляет количество подряд идущих точек по восходящей диагонали
        /// </summary>
        /// <param name="row">строка элемента</param>
        /// <param name="col">столбец элемента</param>
        /// <param name="dot">символ</param>
        /// <returns></returns>
        private static int DotsInUpDiagonal(int row, int col, char dot)
        {
            int result = 0, curSum = 0;
            char prevDot = '.';
            while (row >=0 && col < _field.GetLength(1))
            {
                if (_field[row, col] == dot) // если текущий символ - тот который ищем, прибавляем счетчик
                {
                    curSum++;
                    if (row == 0 || col == _field.GetLength(1) - 1)  // если дошли до первой строки или до последнего столбца, записываем результат и выходим
                    {
                        result = curSum;
                        break;
                    }
                }
                else    // если встретили другой символ
                {
                    result = curSum > result ? curSum : result;  //  если текущая сумма больше ранее найденной - записываем ее как наибольшую
                    curSum = 0;
                }

                row--;
                col++;
                prevDot = dot;
            }
            return result;
        }

        /// <summary>
        /// Вычисляет, заполнено ли все поле? Если заполнено, устанавливает _gameOver = true
        /// </summary>
        private static void CheckFullField()
        {
            int filledCells = 0;
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    filledCells += _field[i, j] != '.' ? 1 : 0;
                }
            }
            _gameOver = filledCells == FIELD_X_SIZE * FIELD_Y_SIZE;
        }

        /// <summary>
        /// Ход AI
        /// </summary>
        private static void AITurn()
        {
            do
            {
                int x = new Random().Next(1, FIELD_X_SIZE + 1);  // Генерируем число от 1 до размера поля FIELD_X_SIZE
                int y = new Random().Next(1, FIELD_Y_SIZE + 1);  // Генерируем число от 1 до размера поля FIELD_Y_SIZE
                if (_field[y-1, x-1] == '.')
                {
                    _field[y-1, x-1] = AI_DOT;
                    break;
                }
            } while (true);
            DrawField();
            CheckVictory();
        }

        private static void PlayerTurn()
        {
            do
            {
                int y = GetIntFromConsole("Введите строку:", 1, FIELD_Y_SIZE);
                int x = GetIntFromConsole("Введите столбец:", 1, FIELD_X_SIZE);

                if (_field[y - 1, x - 1]=='.')
                {
                    _field[y - 1, x - 1] = USER_DOT;
                    break;
                }

                Console.WriteLine("Ячейка занята, выберите другую!");
            } while (true);
            DrawField();
            CheckVictory();
        }

        private static void DrawField()
        {
            Console.Clear();
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    Console.Write(_field[i,j]+"|");
                }
                Console.WriteLine("");
            }
        }

        private static void InitField()
        {
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    _field[i, j] = '.';
                }
            }
        }

        /// <summary>
        /// Метод, созданный для испытания процесса декомпиляции. 
        /// </summary>
        private static void Lottrey()
        {
            var num = GetIntFromConsole("Введите число от 1 до 10:", 1, 10);
            int rnd = new Random().Next(1, 10);
            if (num == rnd)
            {
                Console.WriteLine($"==============================\nВыпало число {rnd}! Вы угадали! Получаете приз!\n==============================");
                return;
            }

            Console.WriteLine($"Увы. Вы не угадали, выпало число {rnd}. (нажмите Enter для продолжения)");
            Console.ReadLine();

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
