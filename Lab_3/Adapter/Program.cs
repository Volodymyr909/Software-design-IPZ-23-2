using Adapter;

public class Program
{
    public static void Main(string[] args)
    {
        Logger consoleLogger = new Logger();
        consoleLogger.Log("This is a log message.");
        consoleLogger.Error("This is an error message.");
        consoleLogger.Warn("This is a warning message.");

        FileWriter fileWriter = new FileWriter("log.txt");
        FileLoggerAdapter fileLogger = new FileLoggerAdapter(fileWriter);
        fileLogger.Log("This is a log message.");
        fileLogger.Error("This is an error message.");
        fileLogger.Warn("This is a warning message.");

        Console.WriteLine("Logging complete. Check log.txt for file logger output.");
    }
}
