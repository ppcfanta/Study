int GetIntFromConsole(string msg)
{
    Console.Write($"{msg}: ");
    return Convert.ToInt32(Console.ReadLine());
}


int[,] Create2DArrayInt()
{
    int rows = GetIntFromConsole("Введите количество строк массива");
    int cols = GetIntFromConsole("Введите количество столбцов массива");
    return new int[rows, cols];
}

float[,] Create2DArrayFloat()
{
    int rows = GetIntFromConsole("Введите количество строк массива");
    int cols = GetIntFromConsole("Введите количество столбцов массива");
    return new float[rows, cols];
}

// fill 2D array with random int numbers between minRnd and maxRnd
void RandomFill2DArrayInt(int[,] arr, int minRnd, int maxRnd)
{
    var rnd = new Random();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = rnd.Next(minRnd, maxRnd);
        }
    }
}

// fill 2D array with random float numbers between minRnd and maxRnd
void RandomFill2DArrayFloat(float[,] arr, float minRnd, float maxRnd)
{
    var rnd = new Random();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = (float)Math.Round(rnd.NextSingle() * (maxRnd - minRnd) + minRnd, 2);
        }
    }
}

// print 2D float array with message(msg) and serarator(default=tab)
void Print2DArrayFloat(float[,] arr, string msg = "", char sep = '\t')
{
    if (msg.Length != 0)
    {
        Console.WriteLine($"{msg}:");
    }

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]:f2}{sep}");
        }

        Console.WriteLine();
    }
}

// print 2D int array with message(msg) and serarator(default=tab)
void Print2DArrayInt(int[,] arr, string msg = "", char sep = '\t')
{
    if (msg.Length != 0)
    {
        Console.WriteLine($"{msg}:");
    }

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]}{sep}");
        }

        Console.WriteLine();
    }
}


// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// Console.WriteLine("\n============== Задача 47 ==============");
// float[,] array = Create2DArrayFloat();
// RandomFill2DArrayFloat(array, -10, 20);
// Print2DArrayFloat(array, $"\nМассив {array.GetLength(0)}x{array.GetLength(1)} случайных вещественных чисел");


// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
// и возвращает значение этого элемента или же указание, что такого элемента нет.
Console.WriteLine("\n============== Задача 50 ==============");
int[,] array2 = Create2DArrayInt();
RandomFill2DArrayInt(array2, 0, 30);
Print2DArrayInt(array2, "Массив целых чисел");
int numPos = GetIntFromConsole("Введите позицию элемента");
if (numPos > array2.GetLength(0) * array2.GetLength(1))
{
    Console.WriteLine("Элемента с такой позицией нету в этом массиве");
}
else
{
    int numRow = numPos / array2.GetLength(1);
    int numCol = (numPos % numRow == 0) ? numPos - (numPos / numRow)

    int numCol = (numRow == 0) ? numPos - 1 : numPos % ((numRow + 1) * array2.GetLength(1)) - 1; // если первая строка

    Console.WriteLine($"Элемент на позиции {numPos}: {array2[numRow, numCol]}");
}