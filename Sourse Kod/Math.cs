using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using static System.Net.WebRequestMethods;

namespace Application
{
    public class Math
    {
        public void MathCurrentDirectory(string CurrentDirectory, string[] Filetypes, bool IsAllFiletypes)
        {
            Console.Clear();

            Console.WriteLine("Рахуємо файли в поточному каталозі.\n");

            int FileCount = 0;

            string[] Files;

            if (IsAllFiletypes)
            {
                Files = Directory.GetFiles(CurrentDirectory);
            }

            else
            {
                Files = Directory.GetFiles(CurrentDirectory, "*.*", SearchOption.AllDirectories)
                    .Where(file => Filetypes.Contains(Path.GetExtension(file)))
                    .ToArray();
            }

            FileCount = Files.Length;

            foreach (string file in Files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine($"\nВсього файлів в каталозі {CurrentDirectory}: {FileCount};");

            Console.ReadKey();
        }

        public void MathSpecificDirectories(string[] FilePaths, string[] Filetypes, bool IsAllFiletypes)
        {
            Console.Clear();

            Console.WriteLine("Рахуємо файли у вказаних каталогах.\n");

            int[] FileCount = new int[FilePaths.Length];
            int TotalFileCount = 0;

            for (int i = 0; i < FilePaths.Length; i++)
            {
                try
                {
                    FileInfo[] Files;
                    DirectoryInfo directory = new DirectoryInfo(@$"{FilePaths[i]}");
                    

                    if (IsAllFiletypes)
                    {
                        Files = directory.GetFiles("*", SearchOption.AllDirectories);
                    }

                    else
                    {
                        List < FileInfo > filteredFiles = new List<FileInfo>();

                        foreach (string fileType in Filetypes)
                        {
                            filteredFiles.AddRange(directory.GetFiles($"*{fileType}", SearchOption.AllDirectories));
                        }

                        Files = filteredFiles.ToArray();
                    }                   

                    FileCount[i] = Files.Length;
                    TotalFileCount += FileCount[i];

                    foreach (FileInfo file in Files) 
                    {
                        Console.WriteLine(file.Name);
                    }                    

                    Console.WriteLine($"\nВсього файлів в каталозі {FilePaths[i]}: {FileCount[i]};");

                    Console.ReadKey();
                }

                catch (Exception ex)
                {
                    Console.WriteLine("\nAn error occurred: " + ex.Message);
                    FileCount[i] = -1;
                }                
            }            

            Console.WriteLine($"\nФайлів в усіх каталогах: {TotalFileCount}.");

            Console.ReadKey();
        }
    }
}
