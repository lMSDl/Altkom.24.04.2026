using System;
using System.Numerics;

namespace ConsoleApp
{
    public static class MathOperations
    {
        /// <summary>
        /// Performs basic arithmetic operations (addition, subtraction, multiplication, division) on two numbers of any numeric type that implements the INumber<T> interface.
        /// </summary>
        /// <typeparam name="T">The numeric type that implements the INumber<T> interface.</typeparam>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The result of the arithmetic operation.</returns>
        public static T Sum<T>(T a, T b) where T : INumber<T>
        {
            return a + b;
        }


        /// <summary>
        /// Performs subtraction on two numbers of any numeric type that implements the INumber<T> interface.
        /// </summary>
        /// <typeparam name="T">The numeric type that implements the INumber<T> interface.</typeparam>
        /// <param name="a">The first number (minuend).</param>
        /// <param name="b">The second number (subtrahend).</param>
        /// <returns>The result of subtracting b from a.</returns>
        public static T Subtract<T>(T a, T b) where T : INumber<T>
        {
            return a - b;
        }

        /// <summary>
        /// Performs multiplication on two numbers of any numeric type that implements the INumber<T> interface.
        /// </summary>
        /// <typeparam name="T">The numeric type that implements the INumber<T> interface.</typeparam>
        /// <param name="a">The first number (multiplicand).</param>
        /// <param name="b">The second number (multiplier).</param>
        /// <returns>The result of multiplying a by b.</returns>
        public static T Multiply<T>(T a, T b) where T : INumber<T>
        {
            return a * b;
        }

        /// <summary>
        /// Performs division on two numbers of any numeric type that implements the INumber<T> interface.
        /// </summary>
        /// <typeparam name="T">The numeric type that implements the INumber<T> interface.</typeparam>
        /// <param name="a">The first number (dividend).</param>
        /// <param name="b">The second number (divisor).</param>
        /// <returns>The result of dividing a by b.</returns>
        /// <exception cref="DivideByZeroException">Thrown when b equals zero.</exception>
        public static T Divide<T>(T a, T b) where T : INumber<T>
        {
            if (b == T.Zero)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }

        /// <summary>
        /// Raises a number to the power of an exponent (integer) using exponentiation by squaring.
        /// </summary>
        /// <typeparam name="T">The numeric type that implements the INumber<T> interface.</typeparam>
        /// <param name="value">The base value.</param>
        /// <param name="exponent">The exponent, must be a non-negative integer.</param>
        /// <returns>The result of raising value to the power of exponent.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when exponent is negative.</exception>
        public static T Power<T>(T value, int exponent) where T : INumber<T>
        {
            if (exponent < 0)
                throw new ArgumentOutOfRangeException(nameof(exponent), "Exponent must be non-negative.");

            T result = T.One;
            T baseValue = value;
            int exp = exponent;

            while (exp > 0)
            {
                if ((exp & 1) == 1)
                    result *= baseValue;

                baseValue *= baseValue;
                exp >>= 1;
            }

            return result;
        }

    }
}