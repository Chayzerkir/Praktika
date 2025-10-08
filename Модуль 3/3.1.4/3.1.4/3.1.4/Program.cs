using System;
using System.Collections.Generic;
using System.Linq;

delegate bool Filter(string item);

class DataManager
{
    private List<string> data = new List<string>();

    public void AddData(string item)
    {
        data.Add(item);
    }

    public IEnumerable<string> FilterData(Filter filter)
    {
        foreach (var item in data)
        {
            if (filter(item))
                yield return item;
        }
    }
}

class Program
{
    static Filter KeywordFilter(string keyword)
    {
        return (string item) => item.Contains(keyword, StringComparison.OrdinalIgnoreCase);
    }

    static bool LengthFilter(string item)
    {
        return item.Length > 5;
    }

    static bool DateFilter(string item)
    {
        return item.StartsWith("2025.");
    }

    static void Main()
    {
        DataManager manager = new DataManager();

        manager.AddData("2025.10.08 Встреча с клиентом");
        manager.AddData("Срочное письмо от директора");
        manager.AddData("2024.12.31 Новый год");
        manager.AddData("Задача: написать отчёт");

        while (true)
        {
            Console.WriteLine("\n1. Добавить данные");
            Console.WriteLine("2. Применить фильтр");
            Console.Write("\nВыберите действие: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("\nВведите строку: ");
                string input = Console.ReadLine();
                manager.AddData(input);
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nВыберите фильтр:");
                Console.WriteLine("1. По ключевому слову");
                Console.WriteLine("2. По длине строки (> 5 символов)");
                Console.WriteLine("3. По дате (строки, начинающиеся с '2025.')");
                string filterChoice = Console.ReadLine();

                Filter filter = null;

                switch (filterChoice)
                {
                    case "1":
                        Console.Write("Введите ключевое слово: ");
                        string keyword = Console.ReadLine();
                        filter = KeywordFilter(keyword);
                        break;
                    case "2":
                        filter = LengthFilter;
                        break;
                    case "3":
                        filter = DateFilter;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        continue;
                }
                Console.Clear();

                Console.WriteLine("\n------ Отфильтрованные данные ------");
                foreach (var item in manager.FilterData(filter))
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("-------------------------------------");
            }
            else
            {
                Console.WriteLine("Неверный выбор!");
            }
        }
    }
}
