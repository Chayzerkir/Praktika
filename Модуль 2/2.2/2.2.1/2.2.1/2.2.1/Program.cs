using System.Collections.Specialized;

class BankAccount
{
    public int ID;
    public string User;
    public double Balance;

    public BankAccount(int id, string user, double balance)
    {
        Console.WriteLine("Банковский аккаунт создан!\n");
        ID = id;
        User = user;
        Balance = balance;
    }

    public void Print()
    {
        Console.WriteLine($"\nИнформация об аккаунте:\nПользователь: {User}\nID: {ID}\nБаланс: {Balance}\n");
    }

    public void ChangeValues()
    {
        Console.WriteLine("Хотите поменять значения у аккаунта?(да/нет)");
        string answer = Console.ReadLine();

        while (string.Compare(answer, "да") != 0 && string.Compare(answer, "нет") != 0)
        {
            Console.WriteLine("\nВведено неверно!");
            answer = Console.ReadLine();
        }

        if (string.Compare(answer, "да") == 0)
        {
            Console.WriteLine("\nВведите через enter новые значения:");
            Console.Write("Пользователь: "); User = Convert.ToString(Console.ReadLine());
            Console.Write("ID: "); ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Баланс: "); Balance = Convert.ToDouble(Console.ReadLine());

            Print();
        }
    }

    public void AddBalance()
    {
        Console.WriteLine("Хотите пополнить баланс?(да/нет)");
        string answer = Console.ReadLine();

        while (string.Compare(answer, "да") != 0 && string.Compare(answer, "нет") != 0)
        {
            Console.WriteLine("\nВведено неверно!");
            answer = Console.ReadLine();
        }

        if (string.Compare(answer, "да") == 0)
        {
            Console.Write("\nВведите сумму пополнения: "); Balance += Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Баланс пополнен!");

            Print();
        }
    }

    public void MinusBalance()
    {
        Console.WriteLine("Хотите снять средства?(да/нет)");
        string answer = Console.ReadLine();

        while (string.Compare(answer, "да") != 0 && string.Compare(answer, "нет") != 0)
        {
            Console.WriteLine("\nВведено неверно!");
            answer = Console.ReadLine();
        }

        if (string.Compare(answer, "да") == 0)
        {
            Console.Write("\nВведите сумму для снятия: "); Balance -= Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Средства сняты!");

            Print();
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount(01, "Egor", 999.9);
      
        account.Print();
        account.ChangeValues();
        account.AddBalance();
        account.MinusBalance();
    }
}