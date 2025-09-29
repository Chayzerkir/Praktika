
class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int RandNum = rnd.Next(1, 100);
        Console.WriteLine("Угадайте, какое число сгенерировал компьютер!\nВведите число, чтобы угадать: ");
        int num = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(RandNum);
        while (RandNum != num)
        {
            if (num> RandNum)
            {
                Console.WriteLine("Нет! Загаданное число меньше!");
            }
            if (num < RandNum)
            {
                Console.WriteLine("Нет! Загаданное число больше!");
            }
            Console.WriteLine("Введите другое число!");
            num = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("Ура, вы угадали!");
    }
}