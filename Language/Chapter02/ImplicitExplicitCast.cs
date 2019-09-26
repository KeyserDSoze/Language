using System;
using System.Collections.Generic;
using System.Text;

namespace Language.Chapter02.Miscellaneous
{
    //Chapter 2
    public class ImplicitExplicitCastAndConversion : ILanguage
    {
        public void DoWork()
        {
            float a = 3;
            double b = a; //implicit cast cause double is greater than float.
            int c = 4;
            byte d = (byte)c; //it's necessary to explicit casting cause byte lesser than int.
            Sample sample = 3; //It's possible cause implicit operator that we have created.
            string text = "9.11E-31";
            float e = float.Parse(text); //it's possible to use float.parse
            e = System.Convert.ToSingle(text); //or the class of System, Convert.
            if (float.TryParse(text, out e))
                Console.WriteLine($"float.TryParse (or any TryParse) returns a bool, true means that the conversion has been done, false hasn't {e}");
        }
    }
    public class Sample
    {
        public int X { get; set; }
        public static implicit operator Sample(int x)
        {
            return new Sample() { X = x };
        }
    }
}
