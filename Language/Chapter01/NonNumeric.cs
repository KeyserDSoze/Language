using System;
using System.Collections.Generic;
using System.Text;

namespace Language.Chapter01.Primitive
{
    //Chapter 1
    public class NonNumeric : ILanguage
    {
        public string AJD { get; set; }
        public NonNumeric()
        {
            string a = "";
        }
        public void DoWork()
        {
            bool value = true;
            Console.WriteLine("A boolean is a 1 bit information");
            Console.WriteLine($"boolean: {value} ");
            Console.WriteLine(string.Empty);
            Console.WriteLine("A char is a 16 bit (2 bytes) information like an ushort (UTF-16 encoding)");
            Console.WriteLine($"char: {20}:{(char)20} ");
            Console.WriteLine("Escape character '\\\\' --> " + '\\');
            Console.WriteLine("It's possible to use unicode \\u0022 --> " + '\u0022');
            Console.WriteLine(string.Empty);
            Console.WriteLine("String is an immutable type. Every change of a string is a new string");
            Console.WriteLine(@"With @ at the start, a string becomes a verbatim string, it's not needed \ for escape, the unique escape is "" for example """" to escape it");
            Console.WriteLine($"With $ at the start, a string becomes an interpolated string, it's possible to insert variable in curly brackets {'\u007b' + "a variable" + '\u007D'}");
            Console.WriteLine($@"Furthermore it's possible to use $ and @ together to have an interpolated verbatim string");
            ConcatenationList();
            Console.WriteLine(string.Empty);
            decimal monetaryNumber = 1_234.56M;
            Console.WriteLine("Representation as string");
            Console.WriteLine($"{monetaryNumber,20:C2} is equal to " + monetaryNumber.ToString("C2") + " monetaryNumber,20:C2 --> monetaryNumber = value, 20 is right-padding, and C2 is the format, for example C2 stands for only 2 decimal numbers");
            string aa = null;
            Console.WriteLine($"It's possible to assign null to a string {aa?.ToString()}");
            MemoryAddressForAStringInHeap();
        }
        private static void ConcatenationList()
        {
            DateTime start = DateTime.UtcNow;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 65535; i++) sb.Append($"{i}:{(char)i} ");
            Console.WriteLine($"Concatenation with StringBuilder, efficiency: {DateTime.UtcNow.Subtract(start).TotalMilliseconds} ms");
            start = DateTime.UtcNow;
            string appendingString = "";
            for (int i = 0; i < 65535; i++) appendingString += $"{i}:{(char)i} ";
            Console.WriteLine($"Concatenation with +=, efficiency: {DateTime.UtcNow.Subtract(start).TotalMilliseconds} ms");
        }
        private unsafe static void MemoryAddressForAStringInHeap()
        {
            string a;
            a = "abcdef";
            Console.WriteLine("String is a managed object, and it's the unique primitive that resides in Heap. String is immutable to keep the strenght of a stack object. Because this, string has no memory position (peculiarity of managed/heap type)");
            fixed (char* p = a)
            {
                Console.WriteLine("Ptr: " + ((int)p).ToString());
                Console.WriteLine("Len: " + (*((int*)p - 1) & 0x3fffffff).ToString());
            }
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
