using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public static void replace(int[] arr, int[] arr1, int q, int x, int n, string[] str)//functon
        {
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(str[i]);
            }
            for(int i = 0; i < n; i++)
            {
                for(int j = q; j < x; j++)
                {
                    arr1[j] = arr[i];
                }
            }
            for (int i = 0; i < x; i++)
            {
                Console.Write(arr1[i] + " ");
            }
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());//size of array
            int[] arr = new int[n];//one dim array with size n
            int x = n * 2; //multiply by 2 to 2nd array            
            int q = 0; //new int 
            int[] arr1 = new int[x]; //one dim array with size x
            string s = Console.ReadLine();//transfer the string 
            string[] str = s.Split(); //Every element splitted by space
            replace(arr, arr1, q, x, n, str); //calling function
        }
    }
}
