using System;

namespace Demo.Finance
{
    public sealed class Month : IEquatable<Month>, IComparable<DateTime>, IComparable<Date>, IComparable<Month>, IComparable<Timestamp>
    {
        private Date Value { get; }

        public Month(int year, int month)
        {
            Value = new Date(year, month, 1);
        }

        public bool Equals(Month other)
        {
            if (other is null) return false;

            if (ReferenceEquals(this, other)) return true;

            return Equals(Value, other.Value);
        }

        public int CompareTo(DateTime other) => Value.CompareTo(other);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if (ReferenceEquals(this, obj)) return true;

            return obj is Month && Equals((Month) obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }

        public static bool operator ==(Month a, Month b) => (a is null && b is null) || (!(a is null) && a.Equals(b));

        public static bool operator !=(Month a, Month b) => !(a == b);

        public int CompareTo(Timestamp other) => -other.CompareTo(Value);

        public int CompareTo(Date other) => -other.CompareTo(Value);

        public int CompareTo(Month other) => Value.CompareTo(other.Value);
    }
}
