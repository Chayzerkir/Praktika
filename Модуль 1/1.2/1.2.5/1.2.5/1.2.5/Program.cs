class Program
{
    static void Main()
    {
        Console.Write("Введите размерность символьного массива: ");
        int N = int.Parse(Console.ReadLine());
        int SoglN = 0;
        char[] arr = new char[N];
        char[] soglArr = new char[SoglN];
        Random rand = new Random();
        string possibleChar = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁ";

        Console.WriteLine("\nМассив случайных русских букв: ");
        for (int i = 0; i < arr.Length; i++)
        {
            int RandLetter = rand.Next(possibleChar.Length);
            arr[i] = possibleChar[RandLetter];
            Console.Write($"\n{i+1}. {arr[i]}");
            if (Soglasn(arr[i]))
            {
                Array.Resize(ref soglArr, SoglN+=1);
                soglArr[SoglN-1] = arr[i];
            }
        }

        Console.WriteLine("\nМассив согласных букв из первого массива: ");
        for (int i = 0; i < soglArr.Length; i++)
        {
            Console.Write($"\n{i + 1}. {soglArr[i]}");
        }
    }

    static bool Soglasn(char Letter)
    {
        string SoglChar = "ЦКНГШЩЗХЪФВПРЛДЖЧСМТЬБЙ";
        if (SoglChar.Contains(Letter))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}