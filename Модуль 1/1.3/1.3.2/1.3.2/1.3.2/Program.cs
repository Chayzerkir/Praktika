class Programm
{
    static void Main()
    {
        Console.Write("Введите число, которое не должно превышаться суммой случайных чисел: ");
        int Sum = int.Parse(Console.ReadLine());
        int ArrSum = 0;
        int NumOfOper = 0;

        Random random = new Random();
        int[] arr = new int[15];

        Console.Write("\nМассив из элементов: ");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(1, 10);
            Console.Write($"\n{i + 1}. {arr[i]}");
        }

        while (ArrSum < Sum)
        {
            int MaxNum = arr.Max();
            int Index = Array.IndexOf(arr, MaxNum);
            arr[Index] = 0;
            ArrSum += MaxNum;
            NumOfOper++;
            if (ArrSum > Sum)
            {
                ArrSum -= MaxNum;
                NumOfOper--;
            }
        }
       
        Console.WriteLine($"\nПолучившаяся сумма: {ArrSum}");
        Console.WriteLine($"\nВсего задействовано элементов: {NumOfOper}");
    }
}