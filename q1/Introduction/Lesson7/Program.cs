using System.Data;

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

void PrintElementByPos(int[,] arr, int position)
{
    int rows = arr.GetLength(0), cols = arr.GetLength(1);
    if (position > rows * cols)
    {
        Console.WriteLine("Элемента с такой позицией нету в этом массиве");
    }
    else
    {
        int counter = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                counter++;
                if (position == counter)
                {
                    Console.WriteLine($"Элемент на позиции {position}: {arr[i, j]}");
                }
            }
        }
    }
}

void PrintColumnMean(int[,] arr)
{
    int rows = arr.GetLength(0), cols = arr.GetLength(1);

    Console.WriteLine("Среднее арифметическое каждого столбца:");
    for (int i = 0; i < cols; i++)
    {
        float columnSum = 0;
        for (int j = 0; j < rows; j++)
        {
            columnSum += arr[j, i];
        }

        Console.Write($"{Math.Round(columnSum / rows, 1)}\t");
    }
}


// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
Console.WriteLine("\n============== Задача 47 ==============");
float[,] array = Create2DArrayFloat();
RandomFill2DArrayFloat(array, -10, 20);
Print2DArrayFloat(array, $"\nМассив {array.GetLength(0)}x{array.GetLength(1)} случайных вещественных чисел");


// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
// и возвращает значение этого элемента или же указание, что такого элемента нет.
Console.WriteLine("\n============== Задача 50 ==============");
int[,] array2 = Create2DArrayInt();
RandomFill2DArrayInt(array2, 0, 30);
Print2DArrayInt(array2, "Массив целых чисел");
int numPos = GetIntFromConsole("Введите позицию элемента");
PrintElementByPos(array2, numPos);


// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
Console.WriteLine("\n============== Задача 52 ==============");
int[,] array3 = Create2DArrayInt();
RandomFill2DArrayInt(array3, 1, 10);
Print2DArrayInt(array3, "Массив целых чисел");
PrintColumnMean(array3);