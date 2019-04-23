using System;

namespace Demo
{
    public class CardExpired : BankCard
    {
        public CardExpired(Month validBefore) : base(validBefore) { }
    }
}