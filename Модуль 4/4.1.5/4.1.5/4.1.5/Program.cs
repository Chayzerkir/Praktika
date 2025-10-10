using System;

interface IDraw
{
    void DrawLine(int length);
    void DrawCircle(int radius);
    void DrawRectangle(int width, int height);
}

class Canvas : IDraw
{
    public void DrawLine(int length)
    {
        Console.WriteLine("Рисуем линию:");
        for (int i = 0; i < length; i++) Console.Write("-");
        Console.WriteLine();
    }

    public void DrawCircle(int radius)
    {
        Console.WriteLine($"\nРисуем круг радиуса {radius} (условно)");
    }

    public void DrawRectangle(int width, int height)
    {
        Console.WriteLine("\nРисуем прямоугольник:");
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++) Console.Write("[]");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        Canvas canvas = new Canvas();

        canvas.DrawLine(10);
        canvas.DrawCircle(5);
        canvas.DrawRectangle(5, 3);
    }
}
