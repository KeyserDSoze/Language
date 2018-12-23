using System;
using System.Collections.Generic;
using System.Text;

namespace Language.Keywords
{
    //Chapter 2
    public class CheckedUnchecked
    {
        public static CheckedUnchecked Instance
        {
            get
            {
                unchecked
                {
                    MakeCheck();
                    int maxValue = int.MaxValue;
                    maxValue = maxValue + 1;
                    Console.WriteLine($"In unchecked: {int.MaxValue} + 1 is: {maxValue}, furthermore operator ++ (maxValue++) would have checked the int.MaxValue and it wouldn't work");
                    byte b = (byte)int.MaxValue;
                    Console.WriteLine($"In unchecked int.MaxValue casts to byte is possible: {b}"); 
                }
                return null;
            }
        }
        public static void MakeCheck()
        {
            checked
            {
                try
                {
                    int maxValue = int.MaxValue;
                    maxValue = maxValue + 1;
                    Console.WriteLine(maxValue);
                }
                catch (Exception er)
                {
                    Console.WriteLine("In Checked maxValue + 1 calls an error: " + er.ToString());
                }
                try
                {
                    int maxValue = int.MaxValue;
                    byte b = (byte)maxValue;
                }
                catch (Exception er)
                {
                    Console.WriteLine("In Checked convert a int.MaxValue to byte is an error:" + er.ToString());
                }
            }
        }
    }
}
