using System;
using System.Linq;

namespace Language.Primitive
{
    /// <summary>
    /// <seealso cref="http://www.binaryconvert.com/"/> to have fun.
    /// </summary>
    public class Numeric
    {
        public static Numeric Instance
        {
            get
            {
                Console.WriteLine("You must prefer keyword name.");
                Console.WriteLine("Integer types");
                Console.WriteLine(string.Empty);
                ToString<sbyte>("keyword sbyte");
                //ToString<SByte>();
                ToString<byte>("keyword byte");
                //ToString<Byte>();
                ToString<short>("keyword short");
                //ToString<Int16>();
                ToString<ushort>("keyword ushort");
                //ToString<UInt16>();
                ToString<int>("keyword int");
                //ToString<Int32>();
                ToString<uint>("keyword uint");
                //ToString<UInt32>();
                ToString<long>("keyword long");
                //ToString<Int64>();
                ToString<ulong>("keyword ulong");
                //ToString<UInt64>();
                Console.WriteLine("A floating point is represented by ±N * 2^k, where N is called Mantissa and K exponent");
                Console.WriteLine("Floating-point types");
                Console.WriteLine("Float has N=24 (3 bytes (1 bit is for sign)) and k=[-149,+104] (1 byte, to represent as int 149) Last 3 bit is for positive infinite, negative infinite and NaN");
                Console.WriteLine(string.Empty);
                ToString<float>("keyword float");
                //ToString<Single>();
                Console.WriteLine("Double has N=53 (6 bytes and 5 bits (1 bit is for sign)) and k=[-1074,+970] (1 byte and 3 bit to represent as int 1074)");
                ToString<double>("keyword double");
                //ToString<Double>();
                Console.WriteLine("A monetary number is represented by ±N * 10^k, where N is called Mantissa and K exponent");
                Console.WriteLine("Decimal(Economic) type");
                Console.WriteLine("Decimal has N=96 (12 bytes) and k=[-28,+0] (4 bytes)");
                Console.WriteLine(string.Empty);
                ToString<decimal>("keyword decimal");
                //ToString<Decimal>();
                Console.WriteLine("Precision for floating point and Literal for hardcoded number");
                Console.WriteLine($"float/Single precision rounded down    '1.2456412f': {1.2456412f} f (or F) stands for float");
                Console.WriteLine($"float/Single precision rounded up      '1.2456419f': {1.2456419F} f (or F) stands for float");
                Console.WriteLine($"double/Double precision rounded down   '1.245641235487943d': {1.245641235487943d} d (or D) stands for double");
                Console.WriteLine($"double/Double precision rounded up     '1.245641235487947d': {1.245641235487947D} d (or D) stands for double");
                Console.WriteLine($"decimal/Decimal precision rounded down '1.24564123548794315646547677627m': {1.24564123548794315646547677621m} m (or M) stands for Monetary (purpose of decimal)");
                Console.WriteLine($"decimal/Decimal precision rounded up   '1.24564123548794315646547677629m': {1.24564123548794315646547677629M} m (or M) stands for Monetary (purpose of decimal)");
                Console.WriteLine("Suffixes for integer are: u for uint32, l for long (Int64), lu or ul for ulong (UInt64)");
                Console.WriteLine(string.Empty);
                Console.WriteLine("By default integer numbers are int, if value is more than int the list of using by compiler is uint, long, ulong");
                Console.WriteLine("By default floating point numbers are double");
                Console.WriteLine($"It's possible to separate numbers for a most comprehensive reading (100_000_000): {100_000_000}");
                Console.WriteLine($"It's possible to use exponential number (6.023e23): {6.023e23}");
                Console.WriteLine($"It's possible to use hexadecimal formatting (0xfa214124fa): {0xfa214124fa} ToString: {0xfa214124fa:X}");
                Console.WriteLine($"It's possible to use binary formatting (0b011101010101011111000111): {0b011101010101011111000111} ToString: {0b011101010101011111000111:X}");
                Console.WriteLine($"It's possible to use round-trip formatting to conserve value of number after a cast from a string that was a number with :R.");
                double numberToCompare = 1.618033988749895;
                double result;
                string text = $"{numberToCompare}";
                result = double.Parse(text);
                Console.WriteLine($"{result == numberToCompare} -> {result} == {numberToCompare} -> {BitConverter.ToString(BitConverter.GetBytes(result))} == {BitConverter.ToString(BitConverter.GetBytes(numberToCompare))} without :R");
                text = $"{numberToCompare:R}";
                result = double.Parse(text);
                Console.WriteLine($"{result == numberToCompare} -> {result} == {numberToCompare} -> {BitConverter.ToString(BitConverter.GetBytes(result))} == {BitConverter.ToString(BitConverter.GetBytes(numberToCompare))} with :R");
                Console.WriteLine(string.Empty);

                return null;
            }
        }
        private static void ToString<T>(string name = "BCL Name (Base Class Library)")
        {
            Type type = typeof(T);
            dynamic min = (T)type.GetField("MinValue").GetValue(null);
            dynamic max = (T)type.GetField("MaxValue").GetValue(null);
            string binaryMin = "No convertible";
            string binaryMax = "No convertible";
            string binaryRandom = "No convertible";
            T divider = (T)Convert.ChangeType(2, type);
            dynamic middleMin = (T)(min / divider);
            dynamic middleMax = (T)(max / divider);
            dynamic random = null;
            int randomValue = 0;
            int weight = 0;
            try
            {
                randomValue = new Random().Next((int)min, (int)max);
                random = (T)Convert.ChangeType(randomValue, type);
            }
            catch
            {
                randomValue = new Random().Next();
                random = (T)Convert.ChangeType(randomValue, type);
            }
            try
            {
                binaryMin = Convert.ToString(middleMin, 2);
                binaryMax = Convert.ToString(middleMax, 2);
                binaryRandom = Convert.ToString(random, 2);
                weight = middleMax <= 255 ? 1 : BitConverter.GetBytes(middleMax).Length;
            }
            catch
            {
                try
                {
                    binaryMin = "";
                    binaryMax = "";
                    binaryRandom = "";
                    foreach (byte b in BitConverter.GetBytes(middleMin)) binaryMin += Convert.ToString(b, 2) + " ";
                    foreach (byte b in BitConverter.GetBytes(middleMax)) binaryMax += Convert.ToString(b, 2) + " ";
                    foreach (byte b in BitConverter.GetBytes(random)) binaryRandom += Convert.ToString(b, 2) + " ";
                    weight = BitConverter.GetBytes(middleMax).Length;
                }
                catch
                {
                    foreach(int i in decimal.GetBits(middleMin)) foreach (byte b in BitConverter.GetBytes(i)) binaryMin += Convert.ToString(b, 2) + " ";
                    foreach (int i in decimal.GetBits(middleMax)) foreach (byte b in BitConverter.GetBytes(i)) binaryMax += Convert.ToString(b, 2) + " ";
                    foreach (int i in decimal.GetBits(random)) foreach (byte b in BitConverter.GetBytes(i)) binaryRandom += Convert.ToString(b, 2) + " ";
                    weight = ((int[])decimal.GetBits(random)).Sum(x => BitConverter.GetBytes(x).Length);
                }
            }
            Console.WriteLine($"{type.Name} with weight: {weight} bytes with min value: {min} and max value: {max} --> {name}");
            try
            {
                Console.WriteLine($"{type.Name} left overflow {min} - 1 = {--min}");
                Console.WriteLine($"{type.Name} right overflow {max} + 1 = {++max}");
            }
            catch (Exception er)
            {
                Console.WriteLine($"{type.Name} overflow not supported");
            }
            binaryMax = binaryMax.Trim();
            binaryMin = binaryMin.Trim();
            binaryRandom = binaryRandom.Trim();
            int maxValue = binaryMax.Length > binaryMin.Length ? binaryMax.Length : binaryMin.Length;
            binaryMax = NormalizeWithZero(binaryMax, maxValue);
            binaryMin = NormalizeWithZero(binaryMin, maxValue);
            binaryRandom = NormalizeWithZero(binaryRandom, maxValue);
            Console.WriteLine($"{type.Name} first example --> {middleMin} = {binaryMin}");
            Console.WriteLine($"{type.Name} second example --> {middleMax} = {binaryMax}");
            Console.WriteLine($"{type.Name} random example --> {random} = {binaryRandom} from random int {randomValue}");
            Console.WriteLine(string.Empty);
        }
        private static string NormalizeWithZero(string numberAsString, int maxValue)
        {
            string[] arrayOfByte = numberAsString.Split(' ');
            for (int j = 0; j < arrayOfByte.Length; j++) for (int i = arrayOfByte[j].Length; i < maxValue / arrayOfByte.Length; i++) arrayOfByte[j] = "0" + arrayOfByte[j];
            return string.Join(" ", arrayOfByte);
        }
    }
}
