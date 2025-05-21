using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class SmartTextReader
    {
        public char[][] ReadFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                char[][] result = new char[lines.Length][];
                for (int i = 0; i < lines.Length; i++)
                {
                    result[i] = lines[i].ToCharArray();
                }
                return result;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
