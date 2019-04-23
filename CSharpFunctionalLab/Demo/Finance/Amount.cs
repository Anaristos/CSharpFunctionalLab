using System;

namespace Demo.Finance
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

        public virtual Amount Scale(decimal factor) =>  new Amount(Currency, Value * factor);

        public Money PayableAt(Money money, Amount expense, Timestamp time) => money is GiftCard gift
                                                                                     && gift.ValidBefore.CompareTo(time) < 0 ? Amount.Zero(expense.Currency)
                                                                                                                             : money is BankCard card && card.ValidBefore.CompareTo(time) < 0
                                                                                                                             ? Amount.Zero(expense.Currency)
                                                                                                                             : money;
        public static Amount Zero(Currency currency) =>  new Empty(currency);

        public override string ToString() => $"{ Value } { Currency }";
    }
}
