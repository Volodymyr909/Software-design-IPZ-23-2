using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Adapter
{
    public class FileWriter
    {
        private readonly string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(string message)
        {
            File.AppendAllText(_filePath, message);
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}
