using System;
using System.Collections.Generic;
using System.Text;

namespace Language.Instantiation
{
    //Chapter 3
    public class Anonymous
    {
        public static Anonymous Instance
        {
            get
            {
                var anonim = new { X = 1, Y = 2 };
                Console.WriteLine(anonim.X);
                //in C# 7.0 born tuples to create an anonymous object.
                //first method
                (string country, int value) = ("Italy", 4);
                //second method
                string country2;
                int value2;
                (country2, value2) = ("Italy", 4);
                //third method
                (var country3, var value3) = ("Italy", 4);
                //fourth method
                var (country4, value4) = ("Italy", 4);
                //fifth method
                (string country, int value) fifth = ("Italy", 4);
                Console.WriteLine(fifth.country);
                //sixth method
                var sixth = (country: "Italy", value: 4);
                Console.WriteLine(sixth.country);
                //seventh method
                var seventh = ("Italy", 4);
                Console.WriteLine(seventh.Item1);
                //discard a value of a tuple with _
                (string countryNotDiscarded, _) = Get();
                //returns from method
                (string country, int value) discarder = Get();
                Console.WriteLine(discarder.country);
                //from C# 7.1 is possible to infer an external value in a tuple
                string country10 = "Italy";
                int value10 = 4;
                var countryInfo = (country10, value10);
                Console.WriteLine(countryInfo.country10);
                //Before C# 7.0 you can use System.Tuple
                Tuple<string, int> tupleBefore7 = Tuple.Create<string, int>("Italy", 4);
                return null;
            }
        }
        private static (string country, int value) Get()
        {
            return ("Italy", 4);
        }
    }
}
