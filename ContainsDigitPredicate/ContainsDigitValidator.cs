using System;

namespace ContainsDigitPredicate
{
    public class ContainsDigitValidator
    {
        private int digit;

        public int Digit
        {
            get => this.digit;
            set
            {
                if (value >= 0 && value <= 9)
                {
                    this.digit = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Expected digit can not be less than zero and more than nine.");
                }
            }
        }

        public bool Verify(int number)
        {
            if (number == this.digit)
            {
                return true;
            }

            while (number != 0)
            {
                if (Math.Abs(number % 10) == this.digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
