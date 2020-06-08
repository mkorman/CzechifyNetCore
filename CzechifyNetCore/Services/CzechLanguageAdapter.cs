using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzechifyNetCore.Services
{
    public class CzechLanguageAdapter : ILanguageAdapter
    {
        public string Adapt(string text)
        {
            var sb = new StringBuilder();

            var consonants = text.Where(c => !IsVowel(c)).ToArray();

            return new string(consonants).Trim();
        }

        protected bool IsVowel(char c)
        {
            return "aeiouAEIOUáéíóúÁÉÍÓÚ".Contains(c);
        }
    }
}
