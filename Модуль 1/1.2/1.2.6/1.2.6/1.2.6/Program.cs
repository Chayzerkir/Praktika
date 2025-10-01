using System.Collections.Immutable;

class Program
{
    static void Main()
    {
        Random random = new Random();
        double[] arr = new double[10];
        double[] newArr = new double[10];
        double min = -10.0;
        double max = 10.0;

        Console.WriteLine("Массив из 10-ти вещественных чисел: ");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = min + (random.NextDouble() * (max - min));
            Console.Write($"\n{i+1}. {arr[i]:F4}");
        }

        for (int i = 0; i < 10; i++)
        {
            double NumMin = arr.Min();
            int IndNimMin = Array.IndexOf(arr, NumMin);
            newArr[i] = IndNimMin;
            arr[IndNimMin] = double.MaxValue;
        }

        Console.WriteLine("\n\nИндексы по возрастанию значений элементов массива: ");
        for (int i = 0; i < newArr.Length; i++)
        {
            Console.Write($"\n{i + 1}. {newArr[i]+1}");
        }
    }
}