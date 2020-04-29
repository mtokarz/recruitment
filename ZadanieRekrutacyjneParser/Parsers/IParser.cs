using System;
using System.Collections.Generic;

namespace ZadanieRekrutacyjneParser.Parsers
{
    interface IParser<T> 
    {
        public IEnumerable<T> Parse(string data);
    }
}
