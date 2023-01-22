// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
Console.WriteLine("\n============== Задача 41 ==============");
Console.Write("Сколько чисел хотите ввести?: ");
int[] numList = new int[Convert.ToInt32(Console.ReadLine())];
for (int i = 0; i < numList.Length; i++)
{
    Console.Write($"Введите {i+1}-е число: ");
    numList[i] = Convert.ToInt32(Console.ReadLine());
}

int positiveCount = 0;
foreach (int num in numList)
{
    if (num > 0)
    {
        positiveCount++;
    }
}
Console.WriteLine($"Количество введенных положительных чисел: {positiveCount}");


// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями
// y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
// Решаем уравнение: k1*x+b1=k2*x+b2; (k1-k2)x = b2-b1; x=(b2-b1)/(k1-k2)
// Итого, если k1!=k2, то решение: x=(b2-b1)/(k1-k2), ну и y находим по одной из формул: y=k1*x+b1
Console.WriteLine("\n============== Задача 43 ==============");
Console.Write("Введите k1: ");
float k1=Convert.ToSingle(Console.ReadLine());
Console.Write("Введите b1: ");
float b1=Convert.ToSingle(Console.ReadLine());

Console.Write("Введите k2: ");
float k2=Convert.ToSingle(Console.ReadLine());
Console.Write("Введите b2: ");
float b2=Convert.ToSingle(Console.ReadLine());

if (Math.Abs(k1 - k2) > 0)
{
    float x = (b2 - b1)/(k1 - k2);
    float y = k1 * x + b1;
    Console.WriteLine($"Линии пересекаются в точке: x={Math.Round(x, 2)}, y={Math.Round(y, 2)}");
}
else
{
    Console.WriteLine($"Линии не пересекаются!");
}