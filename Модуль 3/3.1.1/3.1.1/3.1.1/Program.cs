delegate int FindS();

class Figure
{
    public int S;
    public static int Soffigure(int operation)
    {
        switch (operation)
        {
            case 1: return 5 * 8;
            case 2: return Convert.ToInt32(Math.PI * 5 * 5);
            case 3: return Convert.ToInt32((8 * 5) / 2);
        }
        return 0;
    }
}

class Rectangle: Figure
{
    public static int Print() => Figure.Soffigure(1);
}

class Circle: Figure
{
    public static int Print() => Figure.Soffigure(2);
}

class Triangle:  Figure
{
    public static int Print() => Figure.Soffigure(3);
}

class Program
{
    static void Main()
    {
        FindS rectangle = Rectangle.Print;
        FindS circle = Circle.Print;
        FindS triangle = Triangle.Print;

        Console.WriteLine("Нахождение площади фигур:");
        Console.WriteLine($"Прямоугольника: {rectangle()}");
        Console.WriteLine($"Круга: {circle()}");
        Console.WriteLine($"Треугольника: {triangle()}");
    }
}