using System;
using System.Collections.Generic;
using System.Text;

namespace Language.Instantiation
{
    //Chapter 3
    public class Arrays
    {
        //Instantiation
        static int[] oneDimension;
        static int[,] twoDimensions;
        public static Arrays Instance
        {
            get
            {
                //Assignment
                oneDimension = new int[3] { 1, 2, 3 };
                twoDimensions = new int[3, 3] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
                Console.WriteLine(twoDimensions[0, 2]);
                //Assignment with runtime allocation of memory through new keyword
                oneDimension = new int[] { 1, 2, 3, 4 };
                Console.WriteLine(twoDimensions[0, 3]);
                //Assignment with default values
                oneDimension = new int[3]; //string is null, int is 0, bool is false, char is \0
                //Jagged Array, it's different from normal multidimensional array, for example you can create different row length
                int[][] jaggedArray = { new int[2] { 1, 2 }, new int[3] { 1, 2, 3 } };
                Console.WriteLine(jaggedArray[0][0]);
                //Method from System.Array
                Array.Sort(oneDimension); //randomize positions
                int resultIndex = Array.BinarySearch(oneDimension, 2);
                Array.Reverse(oneDimension); //the last becomes the first, and viceversa
                Array.Clear(oneDimension, 0, oneDimension.Length); //set default value for all values in array
                Array.Resize(ref oneDimension, 6); //resize my array
                //string is an array of char
                string[] arrayOfString = new string[2]; //it's a Jagged Array of char
                return null;
            }
        }
    }
}
