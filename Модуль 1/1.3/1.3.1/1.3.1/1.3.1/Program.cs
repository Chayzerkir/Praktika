class Program
{
    static void Main()
    {
        Console.WriteLine("Введите через enter числитель и знаменатель дроби для ее сокращения: ");
        int chisl = int.Parse(Console.ReadLine());
        int znamen = int.Parse(Console.ReadLine());
        int NOD = 0;

        if (chisl >= 0 && znamen > 0)
        {
            if (chisl > znamen)
            {
                int i = chisl;
                while (NOD == 0)
                {
                    if (chisl % i == 0 && znamen % i == 0)
                    {
                        NOD = i;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            else if (chisl < znamen)
            {
                int i = znamen;
                while (NOD == 0)
                {
                    if (chisl % i == 0 && znamen % i == 0)
                    {
                        NOD = i;
                    }
                    else
                    {
                        i--;
                    }
                }
            }

            Console.WriteLine($"Сокращенная дробь: {chisl/NOD}/{znamen/NOD}");
        }
        if (chisl < 0)
        {
            Console.WriteLine("Числитель должен быть неотрицательным!");
        }
        if (znamen <= 0)
        {
            Console.WriteLine("Знаменатель должен быть положительным!");
        }

    }
}