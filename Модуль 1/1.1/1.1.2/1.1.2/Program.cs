class Program
{
    static void Main()
    {
        Console.WriteLine("Введите три числа через enter для нахождения среднего арифметического:");
        double n1 = Convert.ToInt32(Console.ReadLine());
        double n2 = Convert.ToInt32(Console.ReadLine());
        double n3 = Convert.ToInt32(Console.ReadLine());
        double MidArif = (n1+n2+n3)/3;
        Console.WriteLine($"Среднее арифметическое: ({n1}+{n2}+{n3})/3 = {MidArif}");
    }
}