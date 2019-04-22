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

        public override decimal Withdraw(Currency currency, decimal amount)
        {
            if (ValidBefore.CompareTo(DateTime.Now) <= 0) return 0;

            return amount;
        }
    }
}
