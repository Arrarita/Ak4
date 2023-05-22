using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Input
    {
        public void InputDirectories(ref string[] FilePaths)
        {
            Console.Clear();

            Console.WriteLine("Введіть шляхи до каталогів, розділені знаком '?' без пробілів:\n");

            char[] Delimiters = { '|', '?', '*' };

            Console.SetCursorPosition(0, Console.CursorTop);
            string UserInput = Console.ReadLine();
            FilePaths = UserInput.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < FilePaths.Length; i++)
            {
                FilePaths[i] = Path.GetFullPath(FilePaths[i]);
            }
        }

        public void InputFiletypes(ref string[] Filetypes)
        {
            Console.Clear();

            Console.WriteLine("Введіть типи шуканих файлів із точкою, розділені пробілами:\n");

            char Delimiter = ' ';

            Console.SetCursorPosition(0, Console.CursorTop);
            string UserInput = Console.ReadLine();
            Filetypes = UserInput.Split(Delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
