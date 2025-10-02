class Shape
{
    public virtual void Area()
    {
        int S = 0;
        Console.WriteLine("Для площади не определена фигура.");
    }

    public virtual void Perimetr()
    {
        int P = 0;
        Console.WriteLine("Для периметра не определена фигура.");
    }
}

class Circle : Shape
{
    public override void Area()
    {
        int r = 5; //везде взял произвольные велечины
        double S = Math.PI * r * r;
        Console.WriteLine($"Площадь круга = {S:F4} см2");
    }

    public override void Perimetr()
    {
        int r = 5;
        double P = 2 * Math.PI * r;
        Console.WriteLine($"Длина окружности = {P:F4} см");
    }
}

class Rectangle : Shape
{
    public override void Area()
    {
        int a = 5;
        int b = 8;
        int S = a * b;
        Console.WriteLine($"Площадь прямоугольника = {S} см2");
    }
    public override void Perimetr()
    {
        int a = 5;
        int b = 8;
        int P = 2 * (a + b);
        Console.WriteLine($"Периметр прямоугольника = {P} см");
    }
}

class Program
{
    static void Main()
    {
        Circle circle = new Circle();
        Rectangle rect = new Rectangle();

        circle.Area();
        circle.Perimetr();

        rect.Area();
        rect.Perimetr();
    }
}