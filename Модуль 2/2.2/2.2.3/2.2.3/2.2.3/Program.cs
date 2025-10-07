using System;
using System.Collections.Generic;

class StringArray
{
    private string[] arr;   
    private int size;       

    public StringArray(int size)
    {
        this.size = size;
        arr = new string[size];
    }

    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= size)
            {
                Console.WriteLine("Ошибка: выход за пределы массива!");
                return null;
            }
            return arr[index];
        }
        set
        {
            if (index < 0 || index >= size)
            {
                Console.WriteLine("Ошибка: выход за пределы массива!");
            }
            else
            {
                arr[index] = value;
            }
        }
    }

    public void PrintAll()
    {
        Console.WriteLine("Массив строк:");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"[{i}] = {arr[i]}");
        }
    }

    public static StringArray ConcatArrays(StringArray a1, StringArray a2)
    {
        if (a1.size != a2.size)
        {
            Console.WriteLine("Ошибка: массивы должны быть одинаковой длины!");
            return null;
        }

        StringArray result = new StringArray(a1.size);
        for (int i = 0; i < a1.size; i++)
        {
            result[i] = a1[i] + a2[i];
        }
        return result;
    }

   
    public static StringArray ConcatUnique(StringArray a1, StringArray a2)
    {
        HashSet<string> set = new HashSet<string>();

        for (int i = 0; i < a1.size; i++)
            if (a1[i] != null) set.Add(a1[i]);

        for (int i = 0; i < a2.size; i++)
            if (a2[i] != null) set.Add(a2[i]);

        StringArray result = new StringArray(set.Count);
        int index = 0;
        foreach (var s in set)
        {
            result[index++] = s;
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        StringArray arr1 = new StringArray(3);
        StringArray arr2 = new StringArray(3);

        arr1[0] = "A";
        arr1[1] = "B";
        arr1[2] = "C";

        arr2[0] = "1";
        arr2[1] = "B";
        arr2[2] = "3A";

        Console.WriteLine("Первый массив:");
        arr1.PrintAll();

        Console.WriteLine("\nВторой массив:");
        arr2.PrintAll();

        Console.WriteLine("\nПоэлементное сцепление:");
        StringArray concat = StringArray.ConcatArrays(arr1, arr2);
        concat.PrintAll();

        Console.WriteLine("\nСлияние без повторов:");
        StringArray merged = StringArray.ConcatUnique(arr1, arr2);
        merged.PrintAll();
    }
}
