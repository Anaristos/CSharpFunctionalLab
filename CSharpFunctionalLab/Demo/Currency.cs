using System;

namespace Demo
{
    public sealed class Currency : IEquatable<Currency>
    {
        public string Symbol { get; }

        private Currency(string symbol)
        {
            Symbol = symbol;
        }

        public static Currency USD => new Currency("USD");
        public static Currency EUR => new Currency("EUR");
        public static Currency JPY => new Currency("JPY");

        public bool Equals(Currency other)
        {
            if (other is null) return false;

            if (ReferenceEquals(this, other)) return true;

            return string.Equals(Symbol, other.Symbol);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((Currency) obj);
        }

        public override int GetHashCode()
        {
            return (Symbol != null ? Symbol.GetHashCode() : 0);
        }

        public static bool operator ==(Currency a, Currency b) => (a is null && object.ReferenceEquals(b, null)) || (!(a is null) && a.Equals(b));

        public static bool operator !=(Currency a, Currency b) => !(a == b);
    }
}
