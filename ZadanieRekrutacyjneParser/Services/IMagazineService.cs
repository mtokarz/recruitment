using System;
using System.Collections.Generic;
using ZadanieRekrutacyjneParser.DataModels;

namespace ZadanieRekrutacyjneParser.Services
{
    public interface IMagazineService
    {
        public IEnumerable<Magazine> ProcessMaterialReportsIntoMagazines(IEnumerable<MaterialReport> materials);
    }
}
