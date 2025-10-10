interface IFigure
{
    double perimetr();
    double area();
}

class Circle : IFigure
{
    public double Radius;

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double perimetr() => Radius * Radius * Math.PI;
    public double area() => 2 * Radius * Math.PI;
}

class Rectangle : IFigure
{
    public double A;
    public double B;

    public Rectangle(double a, double b)
    {
        A = a;
        B = b;
    }

    public double perimetr() => (A + B)*2;
    public double area() => A * B;

}

class Triangle : IFigure
{
    public double BokLeft;
    public double BokRight;
    public double Osnovanie;
    public double High;

    public Triangle(double bokLeft, double bokRight, double osnovanie, double high)
    {
        BokLeft = bokLeft;
        BokRight = bokRight;
        Osnovanie = osnovanie;
        High = high;
    }

    public double perimetr() => BokLeft+ BokRight+ Osnovanie;
    public double area() => (Osnovanie * High)/2;

}

class Program
{
    static void Main()
    {
        Console.WriteLine("Вычисление площадей и периметров разных фигур:");
        Console.Write("Для вычисления велечин круга, введите значение радиуса: ");
        double radius = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("\nДля вычисления величин прямоугольника, введите его стороны через enter: ");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("\nДля вычисления величин треугольника, введите его боковые стороны, основание и высоту через enter: ");
        double bokLeft = Convert.ToDouble(Console.ReadLine());
        double bokRight = Convert.ToDouble(Console.ReadLine());
        double osnovanie = Convert.ToDouble(Console.ReadLine());
        double high = Convert.ToDouble(Console.ReadLine());

        Circle circle = new Circle(radius);
        Rectangle rectangle = new Rectangle(a, b);
        Triangle triangle = new Triangle(bokLeft, bokRight, osnovanie, high);

        Console.WriteLine($"Круг:\n Периметр: {circle.perimetr()}\n Площадь: {circle.area()}");
        Console.WriteLine($"Прямоугольник:\n Периметр: {rectangle.perimetr()}\n Площадь: {rectangle.area()}");
        Console.WriteLine($"Треугольник:\n Периметр: {triangle.perimetr()}\n Площадь: {triangle.area()}");
    }
}