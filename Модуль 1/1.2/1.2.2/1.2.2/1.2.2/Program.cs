using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main()
    {
        int[] array = { 10, 0, -25, 73, 51, 99, -14, -48, 34, 119 };
        Console.Write("Заранее определенный массив: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.Write("\nНапишите, каким значением заменить максимальный элемент: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int arrayNum = array.Max();
        int position = Array.IndexOf(array, arrayNum);
        array[position] = num;

        Console.WriteLine("Получившийся массив: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]} ");
        }
    }
}