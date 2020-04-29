using System;
using System.Collections.Generic;
using System.Linq;
using ZadanieRekrutacyjneParser.DataModels;
using ZadanieRekrutacyjneParser.Parsers;

namespace ZadanieRekrutacyjneParser
{
    public class MaterialParser : IParser<MaterialReport>
    {


        public IEnumerable<MaterialReport> Parse(string data)
        {

            if(String.IsNullOrWhiteSpace(data))
            {
                return null;
            }

            try
            {
                var dataLines = data.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();
                dataLines = dataLines.Where(x => x[0] != '#').ToList();
                var materialReports = new List<MaterialReport>();

                foreach (var line in dataLines)
                {
                    materialReports.AddRange(ParseLine(line));
                }

                return materialReports;
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect format - amount in magazine needs to be a number");
                throw;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Incorrect format - insufficient data");
                throw;
            }
           
        }

        private IEnumerable<MaterialReport> ParseLine(string line)
        {
            var material = line.Split(';');
            var lineMaterialReports = material[2].Split('|')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x =>
                {
                    var magazine = x.Split(',');

                    var materialReport = new MaterialReport
                    {
                        MaterialId = material[1],
                        MaterialName = material[0],
                        MagazineName = magazine[0],
                        Amount = Int32.Parse(magazine[1])
                    };

                    return materialReport;
                }).ToList();

            return lineMaterialReports;
        }
    }

}
