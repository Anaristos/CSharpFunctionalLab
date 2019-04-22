using System;

namespace Demo
{
    public class Empty : SpecificMoney
    {
        public Empty(Currency currency) : base(currency) { }

        public override Money On(Timestamp time) => this;

        public override (Amount, Money) Take(decimal amount) => ((Amount.Zero(Currency), (Money) this));
    }
}