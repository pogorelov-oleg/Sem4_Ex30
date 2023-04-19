////// ЗАДАЧА №30. Усложненный вариант 
////// Нужно написать программу, которая выводит массив из 8 элементов, заполненный рандомными, неповторяющимися числами,  в диапозоне, заданным пользователем. 

while (true)
{
    int countMin = GetUserNumber($"Введите минимальное положительное значение в массиве: ", "ОШИБКА! Вы ввели некорректные значения!");
    int countMax = GetUserNumber($"Введите максимальное положительное значение в массиве: ", "ОШИБКА! Вы ввели некорректные значения!");
    int arrLength = 8;

    if (countMax - countMin >= arrLength - 1)
    {
        int[] arr = GetRandomArray(countMin, countMax, arrLength);
        PrintArray(arr);
        break;
    }
    else
        Console.WriteLine($"ОШИБКА! Слишком маленький диапозон чисел, чтобы заполнить весь массив.");
}

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"| {array[i]} ");
    }
    Console.WriteLine();
}

int[] GetRandomArray(int countMin, int countMax, int length)
{
    int[] array = new int[length];
    InitArrayByNumber(array, -1000);
    for (int i = 0; i < array.Length; i++)
    {
        int random = new Random().Next(countMin, countMax + 1);
        while (CheckNumInArray(array, random))
        {
            random = new Random().Next(countMin, countMax + 1);
        }
        array[i] = random;
    }
    return array;
}

bool CheckNumInArray(int[] arr, int num)
{
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == num) return true;
    }
    return false;
}

int GetUserNumber(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out int userInput))
        {
            return userInput;
        }
        else Console.WriteLine(errorMessage);
    }
}

int[] InitArrayByNumber(int[] arr, int initNumber)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = initNumber;
    }
    return arr;
}

