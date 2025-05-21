using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Authenticator
    {
        private static readonly object padlock = new object();
        private static Authenticator instance = null;

        private Authenticator()
        {
            Console.WriteLine("Аутентифікатор створено");
        }
        public static Authenticator Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Authenticator();
                    }
                    return instance;
                }
            }
        }
        public void Authenticate(string user)
        {
            Console.WriteLine($"Аутентифікація користувача: {user}");
        }
    }
}