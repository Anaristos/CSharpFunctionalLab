using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static bool CanPay(Money money, Amount expense)
        {
            Timestamp now = Timestamp.Now;

            switch (money)
            {
                case Amount amount when amount.Currency == expense.Currency:
                    {
                        return amount.Value >= expense.Value;
                    }

                case GiftCard gift when gift.ValidBefore.CompareTo(now) >= 0 && gift.Currency == expense.Currency:
                    {
                        return gift.Value >= expense.Value;
                    }

                case BankCard card when card.ValidBefore.CompareTo(now) >= 0:
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        static void Main()
        {
            IDictionary<Currency, Money> moneys = new Dictionary<Currency, Money>();

            Money money = new Amount(Currency.USD, 100);

            moneys.Add(Currency.USD, money);

            Console.WriteLine($"Added { money }.");

            if (moneys.ContainsKey(Currency.USD)) Console.WriteLine($"Found { moneys[Currency.USD] }.");

            else Console.WriteLine($"{ Currency.USD } not found.");

            Console.ReadLine();
        }
    }
}