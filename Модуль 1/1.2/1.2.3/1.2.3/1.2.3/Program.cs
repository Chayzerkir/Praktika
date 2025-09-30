class Program
{
    static void Main()
    {
        Console.Write("Введите, сколько простых чисел необходимо вывести на экран: ");
        int N = Convert.ToInt32(Console.ReadLine());
        int SimpleNum = 0;
        int WriteNum = 0;
        while (WriteNum < N)
        {
            SimpleNum++;
            if (IsSimple(SimpleNum))
            {
                if (WriteNum % 10 == 0)
                {
                    Console.Write($"\n{SimpleNum} ");
                }
                else
                {
                    Console.Write($"{SimpleNum} ");
                }
            WriteNum++;
            }
        }
    }

    static bool IsSimple(int N)
    {
        if (N < 2) return false;
        for (int i = 2; i <= (int)(N / 2); i++)
        {
            if (N % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}