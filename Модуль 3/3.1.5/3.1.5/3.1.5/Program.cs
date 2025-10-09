class Sorting
{
    public int[] array  = new int[50];
    public delegate void SortMethod(int[] arr);

    public void RandomArray()
    {
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 100);
        }
    }
    public void PrintArray()
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
    public void Sort(SortMethod method)
    {
        method(array);
    }
    public static void BubbleSort(int[] arr)
    {
        int temp;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public static void QuickSort(int[] arr)
    {
        QuickSortRecursive(arr, 0, arr.Length - 1);
    }

    private static void QuickSortRecursive(int[] arr, int left, int right)
    {
        int i = left, j = right;
        int pivot = arr[(left + right) / 2];

        while (i <= j)
        {
            while (arr[i] < pivot) i++;
            while (arr[j] > pivot) j--;
            if (i <= j)
            {
                int tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
                i++;
                j--;
            }
        }

        if (left < j) QuickSortRecursive(arr, left, j);
        if (i < right) QuickSortRecursive(arr, i, right);
    }
}

class Program
{
    static void Main()
    {
        Sorting sorting = new Sorting();
        sorting.RandomArray();

        Console.WriteLine("Исходный массив:");
        sorting.PrintArray();

        Console.WriteLine("\n\nВыберите метод сортировки:");
        Console.WriteLine("1. Пузырьковая сортировка");
        Console.WriteLine("2. Быстрая сортировка");
        Console.Write("Ваш выбор: ");
        string choice = Console.ReadLine();

        Sorting.SortMethod method = null;

        switch (choice)
        {
            case "1":
                method = Sorting.BubbleSort;
                break;
            case "2":
                method = Sorting.QuickSort;
                break;
            default:
                Console.WriteLine("Неверный выбор!");
                return;
        }

        sorting.Sort(method);

        Console.WriteLine("\nОтсортированный массив:");
        sorting.PrintArray();
    }
}