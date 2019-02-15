using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace myfirstapp
{
    class Program
    {
        class FarManager   // created a new class
        {
            public int cursor;
            public bool ok;
            public int size;

            public FarManager()
            {
                cursor = 0;
                ok = true;
            }
            public void Color(FileSystemInfo fs, int index)    // created a method that shows color
            {
                if (index == cursor)
                    Console.BackgroundColor = ConsoleColor.Blue;

                else if (fs.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

            public void Show(string path)  // Created method to show us files and folders
            {
                Console.BackgroundColor = ConsoleColor.Black;//console color would be black
                Console.Clear();//to clean the console
                DirectoryInfo directory = new DirectoryInfo(path);
                directory = new DirectoryInfo(path);
                FileSystemInfo[] files = directory.GetFileSystemInfos();
                size = files.Length;//file's size equals to size
                for (int i = 0, j = 0; i < files.Length; i++)
                {
                    Color(files[i], j);
                    j++;
                    Console.WriteLine("{0}" + "." + " " + files[i].Name, j);//for example: 1. program.cs
                }
            }
            public void Up() // cursor up - UpArrow
            {
                cursor--;
                if (cursor < 0)
                    cursor = size - 1;
            }
            public void Down() // cursor down - DownArrow
            {
                cursor++;
                if (cursor == size)
                    cursor = 0;
            }
            public void Delete(FileSystemInfo fs) // Function to delete files and folders
            {
                if (fs.GetType() == typeof(DirectoryInfo))//if it's directory
                {
                    Directory.Delete(fs.FullName, true); // Delete folder(true - delete folder with all things inside)
                }
                else
                {
                    FileInfo file = new FileInfo(fs.FullName);
                    fs.Delete();
                }
            }
            public void TextFile(string path) //method that reads .txt file
            {
                Console.BackgroundColor = ConsoleColor.Black; // Change console`s backgroundcolor to black
                Console.Clear(); // Clean console
                StreamReader sr = new StreamReader(path);//Create streamreader to read .txt file
                string s = sr.ReadToEnd();
                Console.WriteLine(s);

                ConsoleKeyInfo k = Console.ReadKey();

                if (k.Key == ConsoleKey.Backspace) // Close .txt file and go outside of it
                {
                    sr.Close();//close stream reader
                    return;//Finish our method
                }
                else
                {
                    TextFile(path);
                }
            }

            public void Start(string path)
            {
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                FileSystemInfo fs = null;
                while (consoleKey.Key != ConsoleKey.Escape) //if you press Esc the programm closes
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    fs = directory.GetFileSystemInfos()[cursor];//Show file/folder where is cursor
                    Show(path);// Calling method Show()
                    if (size != 0)
                    {
                        consoleKey = Console.ReadKey();

                        if (consoleKey.Key == ConsoleKey.UpArrow)
                        {
                            Up();
                        }
                        if (consoleKey.Key == ConsoleKey.DownArrow)
                        {
                            Down();
                        }
                        if (consoleKey.Key == ConsoleKey.Enter)
                        {
                            if (fs.GetType() == typeof(DirectoryInfo))
                            {
                                path = fs.FullName;
                                cursor = 0;
                            }
                            else if (fs.Name.EndsWith(".txt"))// if file end with .txt we call method TextFile();
                                TextFile(fs.FullName);
                        }
                        if (consoleKey.Key == ConsoleKey.Backspace)
                        {
                            directory = directory.Parent;
                            path = directory.FullName;
                            cursor = 0;
                        }
                        if (consoleKey.Key == ConsoleKey.D)
                        {
                            Delete(fs);// We call this method to delete file/folder
                            FileSystemInfo[] files = directory.GetFileSystemInfos();
                            size = files.Length;
                            cursor = 0;
                        }
                        if (consoleKey.Key == ConsoleKey.R)
                        {
                            string s = Console.ReadLine();
                            s = Path.Combine(directory.FullName, s);// We combine string s and directory.fullName
                            if (fs.GetType() == typeof(FileInfo))
                                File.Move(fs.FullName, s);//Use this to rename our file/folder
                            if (fs.GetType() == typeof(DirectoryInfo))
                                Directory.Move(fs.FullName, s);
                        }
                    }
                    else
                    {
                        consoleKey = Console.ReadKey();
                        if (consoleKey.Key == ConsoleKey.Backspace)
                        {
                            directory = directory.Parent;
                            path = directory.FullName;
                            cursor = 0;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            FarManager far = new FarManager();
            far.Start("C:/Users/Aidos/Documents/PP2/week3/TASK");
        }
    }
}