interface IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Фигура для вывода информации не определена.");
    }
}

class Circle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Рисуется круг.");
    }
}

class Rectangle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Рисуется прямоугольник.");
    }
}

class Triangle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Рисуется треугольник.");
    }
}

class Program
{
    static void Main()
    {
        IDrawable[] drawable = new IDrawable[]
        {
            new Circle(),
            new Rectangle(),
            new Triangle()
        };

        foreach (IDrawable drawab in drawable)
        {
            drawab.Draw();
        }
    }
}