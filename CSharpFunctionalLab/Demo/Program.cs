﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            IDictionary<Currency, Money> moneys = new Dictionary<Currency, Money>();

            Money money = new Amount(Currency.USD, 100);

            moneys.Add(Currency.USD, money);

            Console.Write($"Have { money }: ");

            if (moneys.ContainsKey(Currency.USD)) Console.WriteLine($"Found { moneys[Currency.USD] }");

            else Console.WriteLine($"{ Currency.USD } not found.");

            Console.ReadLine();
        }
    }
}