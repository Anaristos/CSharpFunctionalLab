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

        public virtual Amount Add(Amount other) => other == null ? throw new ArgumentNullException(nameof(other)) : other.Currency != Currency
                                                                 ? throw new ArgumentException("Mismatched currency.") : new Amount(Currency, Value + other.Value);

        public virtual Amount Subtract(Amount other) => other == null ? throw new ArgumentNullException(nameof(other)) : other.Currency != Currency
                                                                      ? throw new ArgumentException("Mismatched currency.") : other.Value > Value
                                                                      ? throw new ArgumentException("Insufficient funds.") : new Amount(Currency, Value - other.Value);

        public static Amount Zero(Currency currency) =>  new Empty(currency);

        public override string ToString() => $"{ Value } { Currency }";
    }
}
