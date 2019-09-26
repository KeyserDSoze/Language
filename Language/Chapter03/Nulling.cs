using System;
using System.Collections.Generic;
using System.Text;

namespace Language.Chapter03.Instantiation
{
    //Chapter 3
    public class Nulling : ILanguage
    {
        public void DoWork()
        {
            int? x = null;
            Nullable<int> y = null;
            Console.WriteLine($"value of x: {x}");
            Console.WriteLine($"value of y: {y}");
            //int r = x + y; //it's not possible to convert int? to int (compiler error)
            var r = x + y;
            Console.WriteLine($"value of their sum: {r}");
        }
    }
}
