using System;

Person person = new Person();

person.write();
person.print();

class Person
{
    public int age;
    public string name;
    public string adress;


    public void print()
    {
        Console.WriteLine($"Имя: {name};  Возраст: {age}; Адрес: {adress}");
    }
    public void write()
    {
        Console.WriteLine("Введите данные о человеке:");
        Console.Write("Имя: ");
        name = Console.ReadLine();

        Console.Write("\nВозраст: ");
        age = int.Parse(Console.ReadLine());

        Console.Write("\nАдрес: ");
        adress = Console.ReadLine();
    }
}