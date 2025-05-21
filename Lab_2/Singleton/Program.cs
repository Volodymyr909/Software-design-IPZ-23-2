using Singleton;
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Authenticator authenticator1 = Authenticator.Instance;
        authenticator1.Authenticate("User1");

        Authenticator authenticator2 = Authenticator.Instance;
        authenticator2.Authenticate("User2");

        if (authenticator1 == authenticator2)
        {
            Console.WriteLine("Обидва екземпляри є однаковими (Singleton працює правильно)");
        }
        else
        {
            Console.WriteLine("Екземпляри різні (Singleton реалізовано неправильно)");
        }
    }
}
