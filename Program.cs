using System;
using ConvertSN;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int at, bt;
            string s;
            Console.WriteLine("Input number: ");
            s = Console.ReadLine();
            Console.WriteLine("Input current number system: ");
            at = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input next number system: ");
            bt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Result ");
            Console.WriteLine(ConvertNS.Toany(at, bt, s));
        }
    }
}