using System;

namespace Demo
{
    public class Amount : SpecificMoney
    {
        public decimal Value { get; }

        public Amount(Currency currency, decimal amount) : base(currency)
        {
            if (amount < 0) throw new ArgumentException("Negative amount.");

            Value = amount;
        }

        public override Money On(Timestamp time) => this;

        public override (Amount, Money) Take(decimal amount)
        {
            decimal taken = Math.Min(Value, amount);

            decimal remaining = Value - taken;

            return ((new Amount(Currency, taken), new Amount(Currency, remaining)));
        }

        public static Amount Zero(Currency currency) =>  new Amount(currency, 0);

        public override string ToString() => $"{ Value } { Currency }";
    }
}
