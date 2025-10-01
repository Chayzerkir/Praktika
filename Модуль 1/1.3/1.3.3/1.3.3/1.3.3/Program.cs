class Program
{
    static void Main()
    {
        Random rand = new Random();
        int[,] matrix = new int[3, 3];


        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matrix[i, j] = rand.Next(-50, 50);
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        int[] Sums = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Sums[i] = matrix[i, 0] + matrix[i, 1] + matrix[i, 2];
            Console.WriteLine($"Сумма элементов {i+1}-ой строки: {Sums[i]}");
        }

        for (int i = 0; i < 3 - 1; i++)
        {
            for (int j = i + 1; j < 3; j++)
            {
                if (Sums[i] > Sums[j])
                {
                    // меняем местами суммы
                    int tempSum = Sums[i];
                    Sums[i] = Sums[j];
                    Sums[j] = tempSum;

                    // меняем местами строки матрицы
                    for (int k = 0; k < 3; k++)
                    {
                        int temp = matrix[i, k];
                        matrix[i, k] = matrix[j, k];
                        matrix[j, k] = temp;
                    }
                }
            }
        }

        Console.WriteLine("\nУпорядоченная матрица: ");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                Console.Write($"{matrix[i, j]} ");
            Console.WriteLine();
        }
    }
}