using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Menu
    {     
        public void MenuBeginScreen(string CurrentDirectoryName, ref bool IsCurrentFolder)
        {
            Console.Clear();

            Console.WriteLine($"Ви хочете провести пошук файлів в поточному каталозі, чи в інших?\n");
            Console.WriteLine($"[ENTER] ПОТОЧНИЙ КАТАЛОГ {CurrentDirectoryName}");
            Console.WriteLine($"[SPACE] ІНШІ КАТАЛОГИ (буде надано можливість зазначення)\n");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    {
                        IsCurrentFolder = true;
                        break;
                    }
                case ConsoleKey.Spacebar:
                    {
                        IsCurrentFolder = false;
                        break;
                    }
                default:
                    {
                        MenuBeginScreen(CurrentDirectoryName, ref IsCurrentFolder);
                        break;
                    }
            }
        }

        public void MenuEndScreen()
        {
            Console.Clear();

            Console.WriteLine($"Дякуємо за користування програмою! (с) 2023\n");
            Console.ReadKey();

            Console.Clear();
        }

        public void MenuSelectFiletypes(string CurrentDirectoryName, ref bool IsAllFiletypes)
        {
            Console.Clear();

            Console.WriteLine($"Які типи файлів Ви хочете порахувати?\n");
            Console.WriteLine($"[ENTER] ВСІ");
            Console.WriteLine($"[SPACE] ПЕВНІ (буде надано можливість зазначення)\n");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    {
                        IsAllFiletypes = true;
                        break;
                    }
                case ConsoleKey.Spacebar:
                    {
                        IsAllFiletypes = false;
                        break;
                    }
                default:
                    {
                        MenuSelectFiletypes(CurrentDirectoryName, ref IsAllFiletypes);
                        break;
                    }
            }
        }
    }
}
