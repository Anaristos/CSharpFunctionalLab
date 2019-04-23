using Demo.Finance;

namespace Demo
{
    public class CashProxy : Money
    {
        public Money Implementation { get; }

        public decimal PercentageFee { get; }

        public CashProxy(Money implementation, decimal percentageFee)
        {
            Implementation = implementation;

            PercentageFee = percentageFee;
        }
    }
}
