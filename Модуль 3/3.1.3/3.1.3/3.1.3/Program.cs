using System;
using System.Collections.Generic;

delegate void TaskAction(string task);

class TaskManager
{
    private List<(string, TaskAction)> tasks = new List<(string, TaskAction)>();

    public void AddTask(string taskName, TaskAction action)
    {
        tasks.Add((taskName, action));
    }

    public void ExecuteAll()
    {
        foreach (var (task, action) in tasks)
        {
            action(task);
        }
    }
}

class Program
{
    static void Notification(string task)
    {
        Console.WriteLine($"Уведомление: Задача '{task}' добавлена!");
    }

    static void Log(string task)
    {
        Console.WriteLine($"Лог: Задача '{task}' записана в логи.");
    }

    static void Task(string task)
    {
        Console.WriteLine($"Напоминание: {task}.");
    }

    static void Main()
    {
        TaskManager manager = new TaskManager();

        while (true)
        {
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Выполнить все задачи");
            Console.Write("\nВыберите действие: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("\nВыберите действие для задачи:");
                Console.WriteLine("1 - Уведомление");
                Console.WriteLine("2 - Запись в журнал");
                Console.WriteLine("3 - Напоминание на экран");
                string actionChoice = Console.ReadLine();

                TaskAction action = null;
                switch (actionChoice)
                {
                    case "1": action = Notification; break;
                    case "2": action = Log; break;
                    case "3": action = Task; break;
                    default: Console.WriteLine("Неверный выбор!"); continue;
                }

                Console.Write("Введите название задачи: ");
                string taskName = Console.ReadLine();

                Console.Clear();
                manager.AddTask(taskName, action);
                Console.WriteLine("\nЗадача успешно добавлена!");
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n--------- Выполнение задач ---------");
                manager.ExecuteAll();
                Console.WriteLine("------------------------------------");
            }
            else
            {
                Console.WriteLine("Неверный выбор!");
            }
        }
    }
}
