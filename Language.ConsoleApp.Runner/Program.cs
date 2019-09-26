using Language.Chapter01.Primitive;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Language.ConsoleApp.Runner
{
    class Program
    {
        private static ChapterReader Reader = new ChapterReader();
        static void Main(string[] args)
        {
           
            string result = Reader.WhatDoYouWantToSeeInAction();
            if (result == "exit")
                return;
            do
            {
                try
                {
                    Reader.DoWork(int.Parse(result));
                    Console.Write("Press any button to continue");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException?.Message);
                    Console.Write("Press any button to continue");
                    Console.ReadLine();
                }
            } while ((result = Reader.WhatDoYouWantToSeeInAction()) != "exit");
        }
    }
}
