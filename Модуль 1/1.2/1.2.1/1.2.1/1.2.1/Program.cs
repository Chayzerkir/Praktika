class Program
{
    static void Main()
    {
        Console.Write("Введите размерность массивав: ");
        int N = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[N];
        Console.WriteLine($"\nВведите через enter значение каждого элемента массива: ");
        for (int i = 0; i < N; i++)
        {
            Console.Write($"\n{i}. ");
            array[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 1;i < N; i++)
        {
            int modMax = Math.Abs(array[i]);
            int modMin = Math.Abs(array[i-1]);
            if (modMax < modMin)
            {
                modMax = modMin;
            }
        }
        for (int i = 0;i < N; i++) 
        {

        }
    }
}