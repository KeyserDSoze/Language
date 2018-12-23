using System;
using System.Collections.Generic;
using System.Text;

namespace Language.Instantiation
{
    //Chapter 3
    public class Nulling
    {
        public static Nulling Instance
        {
            get
            {
                int? x = null;
                Nullable<int> y = null;
                //int r = x + y; //it's not possible to convert int? to int (compiler error)
                var r = x + y;
                return null;
            }
        }
    }
}
