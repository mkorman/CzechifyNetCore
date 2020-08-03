using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.WebEncoders.Testing;

namespace CzechifyNetCore.Services
{
    public class CzechLanguageAdapter : ILanguageAdapter
    {
        public string Title => "Czechify!";

        public string Adapt(string text)
        {
            var consonants = text.Where(c => !IsVowel(c)).ToArray();
            var textWithoutVowels = new string(consonants).Trim();
            var funnies = textWithoutVowels.Replace('c', 'č');
            return funnies;
        }

        protected bool IsVowel(char c)
        {
            return "aeiouAEIOUáéíóúÁÉÍÓÚ".Contains(c);
        }
    }
}
