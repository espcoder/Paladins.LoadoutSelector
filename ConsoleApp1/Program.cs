using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How old are you?");
            int age = int.Parse(Console.ReadLine());

            if (age > 50)
            {
                Console.WriteLine("Wow, you are old!!");
            }
            else
            {
                Console.WriteLine("You're a young pup.");
            }

            Console.Read();
        }
    }
}
