using Proxy;

public class Program
{
    public static void Main(string[] args)
    {
        string directoryPath = @"C:\Users\notebook778\Desktop\Політєх 2 курс 2 семестр\КПЗ\Lab_3\Lab_3\Proxy";
        string filePath = Path.Combine(directoryPath, "example.txt");
        string restrictedFilePath = Path.Combine(directoryPath, "example.restricted.txt");

        SmartTextReader reader = new SmartTextReader();
        SmartTextChecker checker = new SmartTextChecker(reader);
        SmartTextReaderLocker locker = new SmartTextReaderLocker(reader, @"^.*\.restricted\.txt$");

        // Створюємо прикладові файли, якщо вони не існують
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "This is the first line of text.\nThis is the second line of text.\nThis is the third line of text.");
        }

        if (!File.Exists(restrictedFilePath))
        {
            File.WriteAllText(restrictedFilePath, "This is a restricted text file.\nAccess is limited.");
        }

        Console.WriteLine("Reading normal file with checker:");
        checker.ReadFile(filePath);

        Console.WriteLine("\nReading restricted file with locker:");
        locker.ReadFile(restrictedFilePath);

        Console.WriteLine("\nReading normal file with locker:");
        locker.ReadFile(filePath);
    }
}
