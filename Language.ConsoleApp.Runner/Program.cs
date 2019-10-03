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
        private static string Result = string.Empty;
        static void Main(string[] args)
        {
            while ((Result = Reader.WhatDoYouWantToSeeInAction()) != "exit")
            {
                try
                {
                    Reader.DoWork(int.Parse(Result));
                    Console.Write("Press any button to continue");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                    Console.Write("Press any button to continue");
                    Console.ReadLine();
                }
            }
        }
    }
}
