using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        public static void Spaces(int lvl)
        {
            for(int i = 0; i < lvl; i++)
            {
                Console.Write("     ");
            }
        }
        public static void Ex(DirectoryInfo dir, int lvl)
        {
            foreach(FileInfo f in dir.GetFiles())
            {
                Spaces(lvl);
                Console.WriteLine(f.Name);
            }
            foreach(DirectoryInfo d in dir.GetDirectories())
            {
                Spaces(lvl);
                Console.WriteLine(d.Name);
                Ex(d, lvl + 1)
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("C:/Users/Aidos/Documensts/PP2/week2/Task3");
            Ex(dir, 0);
        }
    }
}
