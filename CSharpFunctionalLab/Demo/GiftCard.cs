using System;

namespace Demo
{
    public class GiftCard : Amount
    {
        public Date ValidBefore { get; }

        public GiftCard(Currency currency, decimal amount, Date validBefore) : base(currency, amount)
        {
            ValidBefore = validBefore ?? throw new ArgumentNullException(nameof(ValidBefore));
        }

        public override Amount Add(Amount other) => other == null ? throw new ArgumentNullException(nameof(other)) : other.Currency != Currency
                                                                  ? throw new ArgumentException("Mismatched currency.") : new GiftCard(Currency, Value + other.Value, ValidBefore);

        public override Amount Subtract(Amount other) => other == null ? throw new ArgumentNullException(nameof(other)) : other.Currency != Currency
                                                                       ? throw new ArgumentException("Mismatched currency.") : other.Value > Value
                                                                       ? throw new ArgumentException("Insufficient funds.") : new GiftCard(Currency, Value - other.Value, ValidBefore);

        //public override Money On(Timestamp time) => time.CompareTo(ValidBefore) >= 0 ? Amount.Zero(Currency) : this;
    }
}
