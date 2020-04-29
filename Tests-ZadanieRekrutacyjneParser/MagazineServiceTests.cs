using NUnit.Framework;
using System.Collections.Generic;
using ZadanieRekrutacyjneParser.DataModels;
using ZadanieRekrutacyjneParser.Services;

namespace Tests_ZadanieRekrutacyjneParser
{
    class MagazineServiceTests
    {
        MagazineService service;

        [SetUp]
        public void Setup()
        {
            service = new MagazineService();
        }

        [TearDown]
        public void Teardown()
        {
            service = null;
        }

        [Test]
        public void ProcessMaterialReportsIntoMagazines_NullInput()
        {
            IEnumerable<MaterialReport> input =null;
            var output = service.ProcessMaterialReportsIntoMagazines(input);

            Assert.IsNull(output);
        }

        [Test]
        public void ProcessMaterialReportsIntoMagazines_EmptyInput()
        {
            IEnumerable<MaterialReport> input = new List<MaterialReport>();
            var output = service.ProcessMaterialReportsIntoMagazines(input);

            Assert.IsNull(output);
        }

    }
}
