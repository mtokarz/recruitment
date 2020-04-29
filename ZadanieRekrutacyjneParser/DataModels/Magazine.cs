using System;
using System.Collections.Generic;

namespace ZadanieRekrutacyjneParser.DataModels
{
    public class Magazine
    {
        public string Name;
        public int Total;
        public Dictionary<string, int> Materials = new Dictionary<string, int>();

        public Magazine Accumulate(MaterialReport m)
        {
            if(String.IsNullOrEmpty(Name))
            {
                Name = m.MagazineName;
            }
            Total += m.Amount;
            if (Materials.ContainsKey(m.MaterialId))
            {
                Materials[m.MaterialId] += m.Amount;
            }
            else
            {
                Materials.Add(m.MaterialId, m.Amount);
            }

            return this;
        }
   
    }
}
