using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guesser
{
    public static class Program
    {

        //public static void Main(string[] args)
        //{
        //    Console.WriteLine("Please enter your super secure password: ");
        //    string password = Console.ReadLine();
        //    int length = password.Length;
        //    Console.WriteLine("How many threads?");

        //    int threadCount = Convert.ToInt32(Console.ReadLine());

        //    Runner runner = new Runner(password, threadCount, length);

        //    TimeSpan ts = runner.Guesser();

        //    Console.WriteLine(ts.ToString());
        //}

        public static void Main(string[] args) {
            string pw = "1010";
            Runner runner = new Runner(pw, pw.Length);

            TimeSpan ts = runner.Guesser();
            Console.WriteLine(ts.ToString());
        }
    }
}
