class Program
{
    static void Main()
    {
        Console.Write("Введите размерность массива: ");
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите через enter начало и конец диапазона для рандомизации значений в массиве: ");
        int A = int.Parse(Console.ReadLine());
        int B = int.Parse(Console.ReadLine());

        Random rand = new Random();
        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            array[i] = rand.Next(A-1, B);
            Console.Write($"\n{i+1}. {array[i]} ");
        }

        int NumMax = array.Max();
        int NumMin = array.Min();
        int IndMax = Array.IndexOf(array, NumMax);
        int IndMin = Array.IndexOf(array, NumMin);
        Console.WriteLine($"\nИндекс минимального элемента: {IndMin+1}");
        Console.WriteLine($"Индекс максимального элемента: {IndMax+1}");

        if (IndMin < IndMax)
        {
            Console.WriteLine($"Элементы, расположенные между {IndMin+1} и {IndMax+1}:");
            while (IndMin - 1 < IndMax)
            {
                Console.WriteLine($"{IndMin + 1}. {array[IndMin]} ");
                IndMin++;
            }
        }
        else if (IndMin > IndMax)
        {
            Console.WriteLine($"Элементы, расположенные между {IndMin+1} и {IndMax+1}:");
            while (IndMax - 1 < IndMin)
            {
                Console.WriteLine($"{IndMax + 1}. {array[IndMax]} ");
                IndMax++;
            }
        }

    }
}