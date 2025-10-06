using System.ComponentModel.Design;
class Book
{
    public string title;
    public string author;
    
    public void Print()
    {
        Console.WriteLine($"{title} - {author}");
    }
}

class HomeLibrary
{
    private Book[] books = new Book[0];

    public void AddBook()
    {
        Console.Write("Название книги: "); string Title = Console.ReadLine();
        Console.Write("Автор книги: "); string Author = Console.ReadLine();

        Book newBook = new Book { title = Title, author = Author };
        Book[] newBooks = new Book[books.Length + 1];
        for (int i = 0; i < books.Length; i++)
        {
            newBooks[i] = books[i];
        }
        newBooks[newBooks.Length - 1] = newBook;
        books = newBooks;
        Console.WriteLine("Книга добавлена!");
    }

    public void WriteBooks()
    {
        if (books.Length == 0)
        {
            Console.WriteLine("Библиотека пуста!");
        }
        else
        {
            for (int i = 0; i < books.Length; i++)
            {
                Console.Write($"{i + 1}. ");
                books[i].Print();
            }
        }
    }
    public void FindBook()
    {
        if (books.Length == 0)
        {
            Console.WriteLine("Библиотека пуста!");
        }
        else
        {
            Console.WriteLine("Введите название либо автора книги: "); string findBook = Console.ReadLine();

            bool isfound = false;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].title.ToLower().Contains(findBook) || books[i].author.ToLower().Contains(findBook))
                {
                    Console.Write($"{i+1}. ");
                    books[i].Print();
                    isfound = true;
                }
            }

            if (!isfound)
            {
                Console.WriteLine("Такой книги или автора не найдено!");
            }
        }
    }
    public void SortBooks()
    {
        if (books.Length == 0)
        {
            Console.WriteLine("Библиотека пуста!");
        }
        else
        {
            Console.WriteLine("Как отсортировать?");
            Console.WriteLine(" 1. По автору");
            Console.WriteLine(" 2. По названию книги");
            int chose = int.Parse(Console.ReadLine());

            switch (chose)
            {
                case 1:
                    Array.Sort(books, (a, b) => a.author.CompareTo(b.author));
                    break;
                case 2:
                    Array.Sort(books, (a, b) => a.title.CompareTo(b.title));
                    break;
            }
        }  
    }
    public void DeleteBook()
    {
        if (books.Length == 0)
        {
            Console.WriteLine("Библиотека пуста!");
        }
        else
        {
            Console.WriteLine("Введите индекс книги в библиотеке для удаления: ");
            for (int i = 0; i < books.Length; i++)
            {
                Console.Write($"{i + 1}. ");
                books[i].Print();
            }
            Console.WriteLine();
            int index = int.Parse(Console.ReadLine());

            if ((index < 1) || index > books.Length)
            {
                Console.WriteLine("Индекс неверен!");
            }
            else
            {
                Book[] newBooks = new Book[books.Length - 1];

                for (int i = 0, j = 0; i < books.Length; i++)
                {
                    if (i != index - 1)
                    {
                        newBooks[j] = books[i];
                        j++;
                    }
                }
                books = newBooks;
                Console.WriteLine("Книга удалена((");
            }

        }
    }
}

    class Program
{
    static void Main()
    {
        HomeLibrary library = new HomeLibrary();

        while (true)
        {
            PrintMenu();

            int variant = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (variant)
            {
                case 1:
                    library.AddBook();
                    break;

                case 2:
                    library.WriteBooks();
                    break;

                case 3:
                    library.FindBook();
                    break;

                case 4:
                    library.SortBooks();
                    break;

                case 5:
                    library.DeleteBook();
                    break;
            }
        }
    }
    static void PrintMenu()
    {
        Console.WriteLine("\nМеню:");
        Console.WriteLine(" 1. Добавить книгу в библиотеку.");
        Console.WriteLine(" 2. Вывести список всех книг.");
        Console.WriteLine(" 3. Найти книгу в библиотеке.");
        Console.WriteLine(" 4. Отсортировать книги.");
        Console.WriteLine(" 5. Удалить книгу из библиотеки.\n");
    }
}