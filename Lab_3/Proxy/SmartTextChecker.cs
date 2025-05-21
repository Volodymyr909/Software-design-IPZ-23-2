using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class SmartTextChecker
    {
        private readonly SmartTextReader _reader;

        public SmartTextChecker(SmartTextReader reader)
        {
            _reader = reader;
        }

        public char[][] ReadFile(string filePath)
        {
            Console.WriteLine("Attempting to open file...");
            char[][] result = _reader.ReadFile(filePath);
            if (result == null)
            {
                Console.WriteLine("Failed to read the file.");
                return null;
            }
            Console.WriteLine("File successfully read.");
            Console.WriteLine($"Total lines: {result.Length}");
            int totalCharacters = 0;
            foreach (var line in result)
            {
                totalCharacters += line.Length;
            }
            Console.WriteLine($"Total characters: {totalCharacters}");
            Console.WriteLine("File closed.");
            return result;
        }
    }
}
