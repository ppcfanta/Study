int GetIntFromConsole(string msg)
{
    Console.Write($"{msg}: ");
    return Convert.ToInt32(Console.ReadLine());
}

void PrintNumber(int num)
{
    if (num == 0)
    {
        return;
    }

    Console.Write(num > 1 ? "{0}, " : "{0}", num);
    PrintNumber(num - 1);
}

int GetSumInRange(int numStart, int numEnd)
{
    if (numStart > numEnd)
    {
        return 0;
    }

    return numStart + GetSumInRange(numStart + 1, numEnd);
}

int AckermannFunc(int numberM, int numberN)
{
    if (numberM == 0)
    {
        return numberN + 1;
    }

    if (numberN == 0)
    {
        return AckermannFunc(numberM - 1, 1);
    }

    if (numberM > 0 && numberN > 0)
    {
        return AckermannFunc(numberM - 1, AckermannFunc(numberM, numberN - 1));
    }

    return AckermannFunc(numberM, numberN);
}


// Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные
// числа в промежутке от N до 1. Выполнить с помощью рекурсии.
Console.WriteLine("\n============== Задача 64 ==============");
PrintNumber(GetIntFromConsole("Введите число"));


// Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму
// натуральных элементов в промежутке от M до N
Console.WriteLine("\n============== Задача 66 ==============");
int numM = GetIntFromConsole("Введите начало диапазона");
int numN = GetIntFromConsole("Введите конец диапазона");
Console.WriteLine($"Сумма натуральных чисел в диапазоне от {numM} до {numN} равна: " +
                  $"{GetSumInRange(numM, numN)}");

// Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии.
// Даны два неотрицательных числа m и n.
Console.WriteLine("\n============== Задача 68 ==============");
numM = GetIntFromConsole("Введите начальное число M");
numN = GetIntFromConsole("Введите начальное число N");
Console.WriteLine($"Функции Аккермана A({numM},{numN}) = {AckermannFunc(numM, numN)}");