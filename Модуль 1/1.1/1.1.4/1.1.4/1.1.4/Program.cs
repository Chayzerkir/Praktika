using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main()
    {
        int[] array = new int[10];
        Random rand = new Random();
        Console.Write("Массив из 10 случайных чисел: ");
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(0, 100);
            Console.Write(array[i] + " ");
        }
        for (int i = 0;i < array.Length; i++)
        {
            sum += array[i];
        }
        Console.WriteLine($"\nСумма всех элементов = {sum}");
    }
}