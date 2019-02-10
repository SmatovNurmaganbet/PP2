using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        public static bool Isprime(int a) //Function to determine the prime number
        {
            if (a == 1)
                return false;
            int cnt = 0;
            for (int i = 2; i <= a; i++)
            {
                if (a % i == 0) cnt++;
            }
            if (cnt == 1) return true;
            return false;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            String s = sr.ReadToEnd();
            String[] arr = s.Split();
            int[] a = new int[arr.Length];
            sr.Close();
            for (int i = 0; i < arr.Length; i++)
            {
                a[i] = int.Parse(arr[i]);
            }
            StreamWriter sw = new StreamWriter("output.txt");
            for(int i = 0; i < a.Length; i++)
            {
                if (Isprime(a[i]) == true)
                    sw.Write(a[i] + " ");
            }
            sw.Close();
        }
    }
}