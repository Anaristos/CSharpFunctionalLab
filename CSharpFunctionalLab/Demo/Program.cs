using System;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            Amount amt = new Amount(Currency.USD, 100);

            Console.Write($"Have { amt }: ");

            (Amount taken, _) = amt.Of(Currency.USD).Take(50); //Tuple deconstruction example.

            Console.WriteLine($"can take { taken }");

            Console.Write($"Have { amt }: ");

            (Amount nextTaken, _) = amt.Of(Currency.USD).Take(50); //Tuple deconstruction example.

            Console.WriteLine($"can take { nextTaken }");

            Console.ReadLine();




        }
    }
}