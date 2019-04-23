using System;

namespace Demo
{
    public class SpecificCard : SpecificMoney
    {
        private BankCard Card { get; }

        public SpecificCard(Currency currency, BankCard card) : base(currency)
        {
            Card = card ?? throw new ArgumentNullException(nameof(card));
        }

        //public override Money On(Timestamp time) => new SpecificCard(Currency, Card.CardOn(time));

        //public override Tuple<Amount, Money> Take(decimal amount) => Card.Take(Currency, amount);
    }
}
