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

        public override Money On(Timestamp time) => CardOn(time);

        public BankCard CardOn(Timestamp time) => time.CompareTo(ValidBefore) >= 0 ? (BankCard)new CardExpired(ValidBefore) : this;

        public override SpecificMoney Of(Currency currency) => new SpecificCard(currency, this);

        public virtual (Amount, Money) Take(Currency currency, decimal amount) => ((new Amount(currency, amount), (Money)this));
    }
}
