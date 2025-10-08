delegate void Notify(string message);

class Notification
{
    public event Notify Message;
    public event Notify Call;
    public event Notify Mail;

    public void OnMessage(string message)
    {
        Console.WriteLine("\nПолучено сообщение!");
        Message?.Invoke(message);
    }

    public void OnCall(string message)
    {
        Console.WriteLine("\nВам звонят по телефону!");
        Call?.Invoke(message);
    }

    public void OnMail(string message)
    {
        Console.WriteLine("\nВам прислали сообщение на почту!");
        Mail?.Invoke(message);
    }
}

class Program
{
    static void HandMessage(string message)
    {
        Console.Write($"Сообщение: {message}\n");
    }

    static void HandCall(string message)
    {
        Console.Write($"Телефон: {message}\n");
    }

    static void HandMail(string message)
    {
        Console.Write($"Сообщение по почте: {message}\n");
    }

    static void Main()
    {
        Notification notification = new Notification();

        notification.Message += HandMessage;
        notification.Call += HandCall;
        notification.Mail += HandMail;

        notification.OnMessage("Хейоу)");
        notification.OnCall("+375 29102920192091910191282129)");
        notification.OnMail("Извещение о суде. Прийдите в такое-то такое-то время!");
    }
}