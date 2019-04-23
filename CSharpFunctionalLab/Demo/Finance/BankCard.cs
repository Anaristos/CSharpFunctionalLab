using System;

namespace Demo.Finance
{
    public class BankCard : Money
    {
        public Month ValidBefore { get; }

        public BankCard(Month validBefore)
        {
            ValidBefore = validBefore ?? throw new ArgumentNullException(nameof(validBefore));
        }
    }
}
