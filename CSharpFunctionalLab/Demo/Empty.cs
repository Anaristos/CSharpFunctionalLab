using System;

namespace Demo
{
    public class Empty : Amount
    {
        public Empty(Currency currency) : base(currency, 0) { }

        //public override Money On(Timestamp time) => this;

        //public override (Amount, Money) Take(decimal amount) => ((Amount.Zero(Currency), (Money)this));

        public override string ToString() => "0";
    }
}