class Program
{
    static void Main()
    {
        Random rand = new Random();
        int[] array = new int[20];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(0, 100);
        }
        for (int i = 0;i < array.Length; i++)
        {
            if (array[i] % 3 == 0 && array[i] % 5 == 0)
            {
                Console.WriteLine($"FizzBuzz({array[i]})");
            }
            else if (array[i] % 3 == 0)
            {
                Console.WriteLine($"Fizz({array[i]})");
            }
            else if (array[i] % 5 == 0)
            {
                Console.WriteLine($"Buzz({array[i]})");
            }
            else
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}