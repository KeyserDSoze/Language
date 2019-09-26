using System;
using System.Collections.Generic;
using System.Text;

namespace Language
{
    public interface ILanguage
    {
        void DoWork();
    }
    public static class LanguageExtensions
    {
        public static string ToName(this ILanguage language)
            => language.GetType().FullName.Replace("Language.", "");
    }
}
