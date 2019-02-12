using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = "C:/Users/Aidos/Documents/PP2/week2/Task4/path1/t.txt";
            string path2 = "C:/Users/Aidos/Documents/PP2/week2/Task4/path2/t.txt";

            StreamWriter sw = new StreamWriter(path1);
            sw.Write("asd");
            sw.Close();
            FileInfo f = new FileInfo(path1);

            if (f.Exists)
            {
                f.CopyTo(path2, true);
                f.Delete();
            }
        }
    }
}
