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

        public override bool Equals(object obj) => Equals(obj as Currency);

        public bool Equals(Currency other) => !(other is null) && other.Symbol == Symbol;

        //public override int GetHashCode() => Symbol?.GetHashCode() ?? 0;

        public static bool operator ==(Currency a, Currency b) => ReferenceEquals(a, b) || (!(a is null) && a.Equals(b));

        public static bool operator !=(Currency a, Currency b) => !(a == b);

        public override string ToString() => Symbol;
    }
}
