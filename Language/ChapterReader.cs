using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Language
{
    public class ChapterReader
    {
        private IList<ILanguage> Languages = new List<ILanguage>();
        public ChapterReader()
        {
            this.Languages = Assembly.GetAssembly(this.GetType()).GetTypes()
                .Where(x => x.GetInterface("ILanguage") != null)
                .OrderBy(x => x.FullName)
                .Select(x => Activator.CreateInstance(x) as ILanguage)
                .ToList();
        }

        public void DoWork(int value)
        {
            if (value < this.Languages.Count)
                this.Languages[value].DoWork();
        }

        public string WhatDoYouWantToSeeInAction()
        {
            int value = 0;
            foreach (ILanguage language in this.Languages)
                Console.WriteLine($"For {language.ToName()} use {value++}");
            Console.WriteLine("Write 'exit' if you want to close this app.");
            return Console.ReadLine();
        }
    }
}
