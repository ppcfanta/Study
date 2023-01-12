int ToPower(int num, int power)
{
    int result = 1;
    for (int i = 0; i < power; i++)
    {
        result *= num;
    }

    return result;
}

int GetDigitsSum(int num)
{
    int result = 0;
    while (num % 10 > 0)
    {
        result += num % 10;
        num /= 10;
    }

    return result;
}

void RandomFillArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = new Random().Next(10);
    }
}

Console.WriteLine("\n============== Задача 25 ==============");
Console.Write("Введите число: ");
int num = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите степень: ");
int power = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Число {num} в степени {power} равно {ToPower(num, power)}");


Console.WriteLine("\n============== Задача 27 ==============");
Console.Write("Введите число: ");
int num = Convert.ToInt32(Console.ReadLine());
int summ = GetDigitsSum(num);
Console.WriteLine($"Сумма цифр числа {num} равна {GetDigitsSum(num)}");


Console.WriteLine("\n============== Задача 29 ==============");
int[] array = new int[8];
RandomFillArray(array);
Console.WriteLine($"Заполненный случайными числами массив: {String.Join(", ", array)}");