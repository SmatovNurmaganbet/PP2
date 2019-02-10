using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        public static bool ispalindrome(string s)
        {
            for (int i = 0, j = s.Length - 1; i <= j; i++, j--)
            {
                if (s[i] != s[j]) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string s = sr.ReadToEnd();
            if (ispalindrome(s) == true)
            {
                Console.WriteLine("Yes");
            }
            else Console.WriteLine("No");
            Console.ReadKey();
        }
    }
}