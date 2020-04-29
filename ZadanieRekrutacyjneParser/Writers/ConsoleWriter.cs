using System;
using System.Collections.Generic;
using System.Linq;
using ZadanieRekrutacyjneParser.DataModels;
using ZadanieRekrutacyjneParser.ExtensionMethods;

namespace ZadanieRekrutacyjneParser.Writers
{
    class ConsoleWriter : IWriter<IEnumerable<Magazine>>
    {
        public void Write(IEnumerable<Magazine> magazines)
        {
            var sortedMagazines = magazines.SortMagazines();
            foreach (var magazine in sortedMagazines)
            {
                Console.WriteLine(magazine.Name + " (total: " + magazine.Total.ToString() + ")");
                var sortedMaterials = magazine.Materials.OrderBy(x => x.Key);
                foreach (var material in sortedMaterials)
                {
                    Console.WriteLine(material.Key + ": " + material.Value);
                }
                Console.WriteLine();
            }
        }
    }


}
