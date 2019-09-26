using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Language.Chapter04
{
    public class Operators : ILanguage
    {
        public void DoWork()
        {
            //Unary operators
            decimal debt = -1000M; //It's equal to make 0 - 1000M
            short shortNotSupported = 1000;
            //short shortValue = +shortNotSupported; //+ or - are used only for int, uint, long, ulong, float, double, and decimal
            //Binary operators are left associative, only the =assignment is right associative.
            //Arithmetic +addition, -subtraction, *multiplication, /division, %remainder, =result
            //Using like you use it in mathematics
            int numerator = 20;
            int denominator = 11;
            int quotient = numerator / denominator;
            int reminder = numerator % denominator;
            Console.WriteLine($"{numerator} / {denominator} = {quotient} with reminder {reminder}");
            //precedence, first *,/,%
            //then, +,-
            //and with lowest precedence =
            int total = 8 + 5 * 3;
            int totalLike = 8 + (5 * 3);
            int trueTotal = (8 + 5) * 3;
            Console.WriteLine($"total: {total} vs totalLike :{totalLike} vs trueTotal: {trueTotal}");
            //Concept of easier to read
            int multiplicationTest = 3 * 9 / 5 + 20;
            int multiplicationEasyToRead = (3 * 9) / 5 + 20;
            int multiplicationExhageratedEasyToRead = ((3 * 9) / 5) + 20;
            Console.WriteLine($"Same result: {multiplicationTest} vs {multiplicationEasyToRead} vs {multiplicationExhageratedEasyToRead}");
            //Evaluation of method, before every method is evaluated from left to right, after the value is mathematicated
            int resultNumberOne = A() + B() * C();
            //+ is possible to use to concatenate string, make a favor for you, use always $ or String.Join or StringBuilder to concatenating string
            string stringConcat = "A" + "B" + "C";
            //char is an int represantation of a character, it's possible to use this power to make calculations on it
            int distanceFromChar = 'g' - 'a';
            Console.WriteLine($"difference from g and a: {distanceFromChar}");
            char sumFromChars = (char)('a' + 'g');
            Console.WriteLine($"sum from a and g: {sumFromChars} is a 'È'");
            char valuedChar = (char)100;
            Console.WriteLine($"valuedChar: {valuedChar} is a 'd'");
            //trouble with float precision or double precision
            //float example
            float greaterValue = 1234567f;
            float lesserValue = 0.1234567f;
            float sumFromGreaterAndLesser = greaterValue + lesserValue;
            Console.WriteLine($"sumFromGreaterAndLesser: {greaterValue} + {lesserValue} = {sumFromGreaterAndLesser}");
            //Approximation when denominator is not a power of 2
            //double example
            double number = 140.6F;
            Console.WriteLine($"A simple double that is a fraction of 703/5 (5 is not a power of 2) {number}");
#warning It's recommend to use decimal when exact decimal arithmetic is required
            //Confusing equality
            decimal decimalNumber = 4.2M;
            double doubleNumber1 = 0.1f * 42F;
            double doubleNumber2 = 0.1D * 42D;
            float floatNumber = 0.1F * 42F;
            Console.WriteLine($"decimalNumber: {decimalNumber} is not equal to doubleNumber1 casted to decimal: {(decimal)doubleNumber1}");
            Console.WriteLine($"decimalNumber casted to double: {(double)decimalNumber} is not equal to: {doubleNumber1}");
            Console.WriteLine($"decimalNumber casted to float: {(float)decimalNumber} is not equal to: {floatNumber} cause (float)4.2M is not equal to 4.2F");
            Console.WriteLine($"doubleNumber1 vs (double)floatNumber --> {doubleNumber1} {IsEqual(doubleNumber1 == (double)floatNumber)} {(double)floatNumber}");
            Console.WriteLine($"doubleNumber1 vs doubleNumber2 --> {doubleNumber1} {IsEqual(doubleNumber1 == doubleNumber2)} {doubleNumber2}");
            Console.WriteLine($"floatNumber vs doubleNumber2 --> {floatNumber}F {IsEqual(floatNumber == doubleNumber2)} {doubleNumber2}D");
            Console.WriteLine($"(double)4.2F vs 4.2D --> {(double)4.2F} {IsEqual((double)4.2F == 4.2D)} {4.2D}");
            Console.WriteLine($"4.2F vs 4.2D --> {4.2F}F {IsEqual(4.2F == 4.2D)} {4.2D}D");
            //if you, unfortunately, must do an equality from two float or double, subtract two values and see if their difference is less than a tolerance (or use decimal type, not casting)
            float tolerance = 0.1F;
            Console.WriteLine($"doubleNumber1 vs doubleNumber2 with tolerance of {tolerance}F --> {doubleNumber1} {IsEqual(Math.Sqrt(Math.Pow(doubleNumber2 - doubleNumber1, 2)) < tolerance)} {doubleNumber2}");
            //int divisionNotPossible = 4 / 0; //An integer or decimal is not divisible for 0.
            Console.WriteLine($"Float 0 divided for 0: {0f / 0}");
            Console.WriteLine($"Math.Sqrt(-1): {Math.Sqrt(-1)}");
            Console.WriteLine($"Float 4f divided for 0: {4f / 0}");
            Console.WriteLine($"Float -8f divided for 0: {-8f / 0}");
            Console.WriteLine($"Float 3.402823E+38F for 2f (overflowing): {3.402823E+38F * 2F}");
            Console.WriteLine($"Float 4f divided for 0 is equal to Float 3.402823E+38F for 2f: {4f / 0 == 3.402823E+38F * 2F}");
            //It's possible to assign with "compound assignment"
            int valueX = 0;
            valueX += 2; //like valueX = valueX + 2;
            Console.WriteLine($"valueX: {valueX}");
            valueX /= 1;
            //post-increment
            Console.WriteLine($"{valueX} - {valueX++} - {valueX++}");
            //pre-increment
            Console.WriteLine($"{valueX} - {++valueX} - {++valueX} - {valueX}");
            //post-increment with method
            Console.WriteLine($"{PreIncrement(ref valueX)} - {PostIncrement(ref valueX)} - {PostIncrement(ref valueX)} - {PreIncrement(ref valueX)}");
            Interlocked.Increment(ref valueX);
            Console.WriteLine($"Interlocked increment {valueX}");
            Interlocked.Decrement(ref valueX);
            Console.WriteLine($"Interlocked decrement {valueX}");
        }
        private static int PostIncrement(ref int x) => x++;
        private static int PreIncrement(ref int x) => ++x;
        private static int A() => 1;
        private static int B() => 2;
        private static int C() => 3;
        private static string IsEqual(bool check) => check ? "==" : "!=";
    }
}
