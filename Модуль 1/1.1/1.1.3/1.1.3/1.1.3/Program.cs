class Program
{
    static void Main()
    {
        Console.WriteLine("Напишите текст, в котором будем искать подстроку: ");
        string text = Console.ReadLine();
        Console.WriteLine("Напишите подстроку");
        string subtext = Console.ReadLine();
        bool contain = text.Contains(subtext);
        if (contain)
        {
            Console.WriteLine("Подстрока содержится в тексте.");
        }
        else
        {
            Console.WriteLine("Подстрока не содержится в тексте.");
        }
    }
}