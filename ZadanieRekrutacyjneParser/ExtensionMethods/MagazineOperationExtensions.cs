using System;
using System.Collections.Generic;
using System.Linq;
using ZadanieRekrutacyjneParser.DataModels;

namespace ZadanieRekrutacyjneParser.ExtensionMethods
{
    public static class MagazineOperationExtensions
    {
        public static IEnumerable<Magazine> SortMagazines(this IEnumerable<Magazine> magazines)
        {
            var sortedMagazines = magazines.OrderByDescending(x => x.Total)
                .ThenByDescending(x => x.Name);
            return sortedMagazines.ToList();
        }
    }
}
