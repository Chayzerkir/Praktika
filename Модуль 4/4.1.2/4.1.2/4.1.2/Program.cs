using System;

interface IProduct
{
    double GetCost();  
    int GetStock();   
}

class Food : IProduct
{
    public string Name;
    public double Price;
    public int Quantity;

    public Food(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public double GetCost() => Price * Quantity;
    public int GetStock() => Quantity;
}

class Program
{
    static void Main()
    {
        Food chereshnia = new Food("Черешня", 2, 50);
        Food dinya = new Food("Дыня", 5.5, 20);

        Console.WriteLine($"Товар: {chereshnia.Name}, Остаток: {chereshnia.GetStock()}, Общая стоимость: {chereshnia.GetCost()}");
        Console.WriteLine($"Товар: {dinya.Name}, Остаток: {dinya.GetStock()}, Общая стоимость: {dinya.GetCost()}");
    }
}
