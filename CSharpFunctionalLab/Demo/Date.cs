using System;

namespace Demo
{
    public sealed class Date : IEquatable<Date>, IComparable<DateTime>
    {
        private DateTime Value { get; }

        public Date(int year, int month, int day)
        {
            Value = new DateTime(year, month, day);
        }

        public bool Equals(Date other)
        {
            if (other is null) return false;

            if (ReferenceEquals(this, other)) return true;

            return Value.Equals(other.Value);
        }

        public int CompareTo(DateTime other) => Value.CompareTo(other);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((Date) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Date a, Date b) => (a is null && b is null) || (!(a is null) && a.Equals(b));

        public static bool operator !=(Date a, Date b) => !(a == b);
    }
}
