class Author
{
    public string name;
    public int dateofbirth;
}

class Book
{
    public string title;
    public int year;
    public Author author;
    public Book(string title, int year, string name)
    {
        this.title = title;
        this.year = year;

        author = new Author();
        author.name = name;
    }

    public void Print()
    {
        Console.WriteLine($"Книга '{title}' была создана в {year} году.\nСоздал данное произведение сам {author.name}.\n");
    }
}

class Program()
{
    static void Main()
    {
        Book firstBook = new Book("Крутое название", 2025, "Кухаренко Егор");
        Book secondBook = new Book("Хз не придумал", 1053, "Не Кухаренко");

        firstBook.Print();
        secondBook.Print();
    }
}