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

// descending sort lines of 2D array
void DescSort2DArrayLines(int[,] array)
{
    for (int row = 0; row < array.GetLength(0); row++)
    {
        for (int col = 0; col < array.GetLength(1); col++)
        {
            for (int i = 0; i < array.GetLength(1) - 1; i++)
            {
                if (array[row, i] < array[row, i + 1])
                {
                    (array[row, i + 1], array[row, i]) = (array[row, i], array[row, i + 1]);
                }
            }
        }
    }
}

// Функция возвращает номер строки 2D-массива с минимальной суммой элементов
int GetRowNumWithMinSum(int[,] array)
{
    int minRowSum = 0;
    int minRowNum = 0;
    int curRowSum = 0;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        minRowSum += array[0, i];
    }

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            curRowSum += array[i, j];
        }

        if (curRowSum < minRowSum)
        {
            minRowSum = curRowSum;
            minRowNum = i;
        }

        curRowSum = 0;
    }

    return minRowNum + 1;
}

int[,] MultiplyMatrix(int[,] arr1, int[,] arr2)
{
    int[,] resArr = new int[arr1.GetLength(0), arr1.GetLength(1)];

    for (int i = 0; i < arr1.GetLength(0); i++)
    {
        for (int j = 0; j < arr2.GetLength(1); j++)
        {
            resArr[i, j] = 0;
            for (int k = 0; k < arr1.GetLength(1); k++)
            {
                resArr[i, j] += arr1[i, k] * arr2[k, j];
            }
        }
    }

    return resArr;
}

void Print3DArrayWithIndexes(int[,,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.WriteLine();
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                Console.Write($"{arr[i, j, k]}({i},{j},{k})\t");
            }
        }

        Console.WriteLine();
    }
}

void Fill3DArrayNoRepeat(int[,,] arr)
{
    int num = 10;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                arr[k, i, j] += num;
                num += 3;
            }
        }
    }
}

void SpiralFill4x4Array(int[,] array)
{
    int i = 0, j = 0, n = 4;
    int fillValue = 1;
    for (int e = 0; e < n * n; e++)
    {
        int k = 0;
        do
        {
            array[i, j++] = fillValue++;
        } while (++k < n - 1);

        for (k = 0; k < n - 1; k++)
        {
            array[i++, j] = fillValue++;
        }

        for (k = 0; k < n - 1; k++)
        {
            array[i, j--] = fillValue++;
        }

        for (k = 0; k < n - 1; k++)
        {
            array[i--, j] = fillValue++;
        }

        ++i;
        ++j;
        n = n < 2 ? 0 : n - 2;
    }
}


// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Console.WriteLine("\n============== Задача 54 ==============");
int[,] array = Create2DArrayInt();
RandomFill2DArrayInt(array, -5, 20);
Print2DArrayInt(array, "Изначальный массив");
DescSort2DArrayLines(array);
Print2DArrayInt(array, "Массив после сортировки строк");


// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Console.WriteLine("\n============== Задача 56 ==============");
int[,] array2 = Create2DArrayInt();
RandomFill2DArrayInt(array2, 1, 10);
Print2DArrayInt(array2, "Прямоугольный массив");
DescSort2DArrayLines(array2);
Console.WriteLine($"Номер строки с минимальной суммой элементов: {GetRowNumWithMinSum(array2)}");

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Console.WriteLine("\n============== Задача 58 ==============");
int size = GetIntFromConsole("Введите размер матриц");
int[,] array3 = new int[size, size];
int[,] array4 = new int[size, size];
RandomFill2DArrayInt(array3, 1, 5);
RandomFill2DArrayInt(array4, 1, 5);
Print2DArrayInt(array3, "Матрица 1");
Print2DArrayInt(array4, "Матрица 2");
Print2DArrayInt(MultiplyMatrix(array3, array4), "Перемноженная матрица");


// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу,
// которая будет построчно выводить массив, добавляя индексы каждого элемента.
Console.WriteLine("\n============== Задача 60 ==============");
int[,,] array5 = new int[2, 2, 2];
Fill3DArrayNoRepeat(array5);
Print3DArrayWithIndexes(array5);


// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4
Console.WriteLine("\n============== Задача 62 ==============");
int[,] array6 = new int[4, 4];
SpiralFill4x4Array(array6);
Print2DArrayInt(array6);