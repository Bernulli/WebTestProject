using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            
            Console.Write("Enter word: ");
            string str = Console.ReadLine();
            GetFile gf = new GetFile(str);
           

        }
    }
}
