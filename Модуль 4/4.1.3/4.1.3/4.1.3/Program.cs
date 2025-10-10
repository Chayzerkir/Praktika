using System;

interface IStudent
{
    double GetAverageGrade();    
    int GetCourse();     
}

class Student : IStudent
{
    public string Name;
    public int Course;
    public double[] Grades;

    public Student(string name, int course, double[] grades)
    {
        Name = name;
        Course = course;
        Grades = grades;
    }

    public double GetAverageGrade()
    {
        double sum = 0;
        foreach (var g in Grades) sum += g;
        return sum / Grades.Length;
    }

    public int GetCourse() => Course;
}

class Program
{
    static void Main()
    {
        Student student = new Student("Егор", 3, new double[] { 10, 9.6, 9.8, 9.9 });
        Console.WriteLine($"Студент: {student.Name}, Курс: {student.GetCourse()}, Средний балл: {student.GetAverageGrade():F2}");
    }
}
