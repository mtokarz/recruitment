using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZadanieRekrutacyjneParser.DataModels;

namespace ZadanieRekrutacyjneParser.Services
{
    public class MagazineService : IMagazineService
    {
        public IEnumerable<Magazine> ProcessMaterialReportsIntoMagazines(IEnumerable<MaterialReport> materials)
        {
            if(materials == null || !materials.Any())
            {
                return null;
            }
            var magazines = materials.GroupBy(x => x.MagazineName).Select(x =>
                  x.Aggregate(new Magazine(), (acc, m) => acc.Accumulate(m))
            );
            return magazines.ToList();
        }

    }
}
