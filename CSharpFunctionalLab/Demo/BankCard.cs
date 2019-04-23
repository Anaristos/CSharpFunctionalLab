using System;

namespace Demo
{
    public class BankCard : Money
    {
        public Month ValidBefore { get; }

        public BankCard(Month validBefore)
        {
            ValidBefore = validBefore ?? throw new ArgumentNullException(nameof(validBefore));
        }

        public BankCard CardOn(Timestamp time) => time.CompareTo(ValidBefore) >= 0 ? (BankCard)new CardExpired(ValidBefore) : this;

        public virtual (Amount, Money) Take(Currency currency, decimal amount) => ((new Amount(currency, amount), (Money)this));
    }
}
