using System;
using System.IO;
using System.Text;
using Application;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;                   

            string CurrentDirectory = Environment.CurrentDirectory;
            string CurrentDirectoryName = Path.GetFileName(CurrentDirectory);

            string[] FilePaths = { };
            string[] Filetypes = { };

            bool IsCurrentFolder = false;
            bool IsAllFiletypes = false; 

            Menu menu = new Menu();
            Input input = new Input();
            Math math = new Math();

            if (args.Length > 0)
            {
                menu.MenuSelectFiletypes(CurrentDirectoryName, ref IsAllFiletypes);
                FilePaths = args;
            }

            else
            {
                menu.MenuBeginScreen(CurrentDirectoryName, ref IsCurrentFolder);
                menu.MenuSelectFiletypes(CurrentDirectoryName, ref IsAllFiletypes);

                if (!IsCurrentFolder)
                {
                    input.InputDirectories(ref FilePaths);
                }
            }                                 

            if (!IsAllFiletypes)
            {
                input.InputFiletypes(ref Filetypes);
            }

            if (IsCurrentFolder)
            {
                math.MathCurrentDirectory(CurrentDirectory, Filetypes, IsAllFiletypes);
            }

            else
            {
                math.MathSpecificDirectories(FilePaths, Filetypes, IsAllFiletypes);
            }                                                   

            menu.MenuEndScreen();         
        }
    }
}