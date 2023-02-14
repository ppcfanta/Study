// returns count of string array elements with length <= "len"
int GetElementsLenCount(string[] arr, int len)
{
    int elementsCount = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i].Length <= len)
        {
            elementsCount++;
        }
    }

    return elementsCount;
}

// print string array with message(default="") and serarator(default='')
void PrintArrayStr(string[] arr, string msg = "", string sep = ", ")
{
    if (msg.Length != 0)
    {
        Console.WriteLine($"{msg}:");
    }

    for (int i = 0; i < arr.Length; i++)
    {
        if (i == arr.Length - 1)
        {
            sep = String.Empty;
        }

        Console.Write($"{arr[i]}{sep}");
    }

    Console.WriteLine();
}

void FillNewArray(string[] arr, string[] newArr, int len)
{
    int counter = 0;
    foreach (string elem in arr)
    {
        if (elem.Length <= len)
        {
            newArr[counter] = elem;
            counter++;
        }
    }
}


int elementLen = 3;
string[] array = { "Test", "apt", "2d", "Loki", "Foo", "Monday", "eye", "loop" };
string[] newArray = new string[GetElementsLenCount(array, elementLen)];

FillNewArray(array, newArray, elementLen);
PrintArrayStr(array, "Изначальный массив строк");
PrintArrayStr(newArray, "Новый массив строк");