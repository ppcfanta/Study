void RandomFillArrayInt(int[] arr, int minRnd,
    int maxRnd) // fill array with random int numbers between minRnd and maxRnd
{
    var rnd = new Random();
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = rnd.Next(minRnd, maxRnd);
    }
}

void RandomFillArrayFloat(float[] arr) // fill array with random float numbers from -100.00 to 100.00
{
    var rnd = new Random();
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = (float)Math.Round(rnd.NextSingle() * 200 - 100, 2);
    }
}

int GetEvenCount(int[] arr)
{
    int evenCount = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] % 2 == 0)
        {
            evenCount++;
        }
    }

    return evenCount;
}
    Math.Min(Array.GetLength(0))
int GetSummOfOddElements(int[] arr) // считает сумму нечетных элементов
{
    int oddSumm = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (i % 2 == 1)
        {
            oddSumm += arr[i];
        }
    }

    return oddSumm;
}

float GetMinFromFloatArray(float[] arr)
{
    float minElement = arr[0];
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] < minElement)
        {
            minElement = arr[i];
        }
    }

    return minElement;
}

float GetMaxFromFloatArray(float[] arr)
{
    float maxElement = arr[0];
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] > maxElement)
        {
            maxElement = arr[i];
        }
    }

    return maxElement;
}

// Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.
Console.WriteLine("\n============== Задача 34 ==============");
Console.Write("Введите размер массива: ");
int[] array = new int[Convert.ToInt32(Console.ReadLine())];
RandomFillArrayInt(array, 100, 1000);
Console.WriteLine($"Массив случайных трехзначных положительных чисел: {String.Join(", ", array)}");
Console.WriteLine($"Количество четных чисел в массиве: {GetEvenCount(array)}");


// Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
Console.WriteLine("\n============== Задача 36 ==============");
Console.Write("Введите размер массива: ");
int[] array2 = new int[Convert.ToInt32(Console.ReadLine())];
RandomFillArrayInt(array2, -100, 100);
Console.WriteLine($"Массив случайных чисел: {String.Join(", ", array2)}");
Console.WriteLine($"Сумма нечетных элементов массива: {GetSummOfOddElements(array2)}");


// Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
Console.WriteLine("\n============== Задача 38 ==============");
Console.Write("Введите размер массива: ");
float[] array3 = new float[Convert.ToInt32(Console.ReadLine())];
RandomFillArrayFloat(array3);
Console.WriteLine($"Массив случайных вещественных чисел(от -100.00 до 100.00): {String.Join(" ", array3)}");
float min = GetMinFromFloatArray(array3);
float max = GetMaxFromFloatArray(array3);
Console.WriteLine($"Минимальный эелемент массива: {min}");
Console.WriteLine($"Максимальный эелемент массива: {max}");
Console.WriteLine($"Разница между максимальным и минимальным элементов массива: {(float)Math.Round(max - min, 2)}");