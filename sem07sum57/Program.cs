Console.Clear();

Console.Write("Введите количество строк массива: ");
int rows = int.Parse(Console.ReadLine() ?? "");

Console.Write("Введите количество столбцов массива: ");
int columns = int.Parse(Console.ReadLine() ?? "");

int[,] array = GetArray(rows, columns, 0, 10);
PrintArray(array);
Console.WriteLine();

int[,] matr = HowManyNumbers(array);
PrintArray(matr);

int[,] HowManyNumbers(int[,] arr)
{
    int[,] matrix = new int[arr.GetLength(0) * arr.GetLength(1), 2];

    int number = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            int temp = arr[i, j];
            bool isExist = false;
            for (int k = 0; k < number; k++)
            {
                if (matrix[k, 0] == temp) isExist = true;
            }
            if (!isExist)
            {
                matrix[number, 0] = temp;
                number++;
            }
        }
    }
    int[,] collection = new int[number, 2];
    for (int i = 0; i < number; i++)
    {
        collection[i, 0] = matrix[i, 0];
    }
    for (int n = 0; n < number; n++)
    {
        int count = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == collection[n, 0]) count++;
            }
        }
        collection[n, 1] = count;
    }
    return collection;
}


int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]} ");
        }
        Console.WriteLine();
    }
}
