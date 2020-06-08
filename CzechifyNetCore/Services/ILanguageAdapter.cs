using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CzechifyNetCore.Services
{
    public interface ILanguageAdapter
    {
        string Adapt(string text);
    }
}
