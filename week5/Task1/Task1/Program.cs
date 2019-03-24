using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    public class Complex //создаём класс для вывода комплексных чисел по формуле a+bi
    {
        public int real, img;
        public Complex() { }
        public void Print()
        {
            Console.WriteLine($"{real} + {img}i");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex s = new Complex();//объявляем переменную типа Complex
            s.real = int.Parse(Console.ReadLine());//объявляем значения a (real) и b (imaginary)
            s.img = int.Parse(Console.ReadLine());

            //создаём файл .xml куда записываются значения s
            FileStream fs = new FileStream("Complex.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            xs.Serialize(fs, s);//сериализуем значения s в файле fs
            fs.Close();
            
            //считываем значения из раннее созданного файла .xml
            FileStream fs1 = new FileStream("Complex.xml", FileMode.Open, FileAccess.Read);
            //десериализуем все значения в новую переменную s1
            Complex s1 = xs.Deserialize(fs1) as Complex;
            s1.Print();
            fs1.Close();
            Console.ReadKey();
        }
    }
}