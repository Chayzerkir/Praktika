using System;

interface IBook
{
    bool IsAvailable(); 
    void BorrowBook();  
}

class LibraryBook : IBook
{
    public string Title;
    private bool available;

    public LibraryBook(string title, bool available = true)
    {
        Title = title;
        this.available = available;
    }

    public bool IsAvailable() => available;

    public void BorrowBook()
    {
        if (available)
        {
            available = false;
            Console.WriteLine($"Книга \"{Title}\" успешно выдана читателю.");
        }
        else
        {
            Console.WriteLine($"Книга \"{Title}\" уже выдана.");
        }
    }
}

class Program
{
    static void Main()
    {
        LibraryBook book1 = new LibraryBook("Книга о великом Егоре");
        LibraryBook book2 = new LibraryBook("1984", false);

        Console.WriteLine($"\"{book1.Title}\" доступна? - {book1.IsAvailable()}");
        book1.BorrowBook();

        Console.WriteLine($"\"{book2.Title}\" доступна? - {book2.IsAvailable()}");
        book2.BorrowBook();
    }
}
