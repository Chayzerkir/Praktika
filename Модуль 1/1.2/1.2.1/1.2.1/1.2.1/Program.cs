class Program
{
    static void Main()
    {
        Console.Write("Введите размерность массива: ");
        int N = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[N];
        int modMax = 0;
        Console.WriteLine($"\nВведите через enter значение каждого элемента массива: \n");
        for (int i = 0; i < N; i++)
        {
            Console.Write($"{i+1}. ");
            array[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0;i < N; i++)
        {
            int modMin = Math.Abs(array[i]);
            if (modMax < modMin)
            {
                modMax = modMin;
            }
        }
        for (int i = 0;i < N; i++) 
        {
            Console.Write($"\n{i+1}. {array[i]/(double)modMax}");
        }
    }
}