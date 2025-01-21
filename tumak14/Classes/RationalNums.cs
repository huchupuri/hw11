using hw11.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10.Classes
{
    [DeveloperInfo("Маркелов Михаил", "20.01.2025")]
    [DeveloperInfo("Не Михаил")]
    [DeveloperInfo()]
    internal class RationalNums 
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; } 
        public RationalNums(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("знаменатль != 0");

            Numerator = numerator;
            Denominator = denominator;
        }
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
        public override bool Equals(object obj)
        {
            if (obj is RationalNums other)
            {
                return Numerator == other.Numerator && Denominator == other.Denominator;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }
        public static bool operator ==(RationalNums a, RationalNums b) => a.Equals(b);
        public static bool operator != (RationalNums a, RationalNums b) => !a.Equals(b);
        public static bool operator < (RationalNums a, RationalNums b) => a.Numerator/a.Denominator < b.Numerator / b.Denominator;
        public static bool operator >(RationalNums a, RationalNums b) => a.Numerator / a.Denominator > b.Numerator / b.Denominator;
        public static bool operator <=(RationalNums a, RationalNums b) => a.Numerator / a.Denominator <= b.Numerator / b.Denominator;
        public static bool operator >= (RationalNums a, RationalNums b) => a.Numerator / a.Denominator >= b.Numerator / b.Denominator;

        public static RationalNums operator +(RationalNums a, RationalNums b)
        {
            int newNumerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int newDenominator = a.Denominator * b.Denominator;
            return new RationalNums(newNumerator, newDenominator);
        }

        public static RationalNums operator - (RationalNums a, RationalNums b)
        {
            int newNumerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int newDenominator = a.Denominator * b.Denominator;
            return new RationalNums(newNumerator, newDenominator);
        }

        public static RationalNums operator * (RationalNums a, RationalNums b)
        {
            return new RationalNums(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static RationalNums operator / (RationalNums a, RationalNums b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("нельзя делить на 0");
            return new RationalNums(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static RationalNums operator % (RationalNums a, RationalNums b)
        {
            RationalNums div = a / b;
            return a - (b * new RationalNums((int)(div.Numerator / div.Denominator), 1));
        }

        public static RationalNums operator ++(RationalNums a) => a + new RationalNums(1, 1);
        public static RationalNums operator --(RationalNums a) => a - new RationalNums(1, 1);
        public static explicit operator float(RationalNums r)
        {
            return (float)r.Numerator / r.Denominator;
        }
        public static explicit operator int(RationalNums r)
        {
            return r.Numerator / r.Denominator;
        }
        public static implicit operator RationalNums(int num)
        {
            return new RationalNums(num, 1);
        }

    }
}
