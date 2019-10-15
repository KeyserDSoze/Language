using System;
using System.Collections.Generic;
using System.Text;

namespace Language.Chapter09
{
    public class ValueTypeIdionsyncrasies : ILanguage
    {
        public void DoWork()
        {
            Position position = new Position(1, 2);
            //Simple box operation
            object positionObject = position;
            Console.WriteLine((Position)positionObject);

            //Unbox, modify unboxed value, and discard value
            ((Position)positionObject).MoveTo(4, 5);
            Console.WriteLine((Position)positionObject);

            //Box, modify boxed value, and discard reference to box
            ((IPosition)position).MoveTo(6, 7);
            Console.WriteLine((Position)position);
            Console.WriteLine((Position)positionObject);

            //Modify boxed value directly
            ((IPosition)positionObject).MoveTo(7, 8);
            Console.WriteLine((Position)positionObject);
        }
    }
    interface IPosition
    {
        int X { get; }
        int Y { get; }
        void MoveTo(int x, int y);
    }
    struct Position : IPosition
    {
        public int X { get; private set; }

        public int Y { get; private set; }
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void MoveTo(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public override string ToString()
            => $"{this.X}-{this.Y}";
    }
}
