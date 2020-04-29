using System;
using System.Collections.Generic;
using System.Linq;
using ZadanieRekrutacyjneParser.DataModels;
using ZadanieRekrutacyjneParser.InputReaders;
using ZadanieRekrutacyjneParser.Parsers;
using ZadanieRekrutacyjneParser.Services;
using ZadanieRekrutacyjneParser.Writers;

namespace ZadanieRekrutacyjneParser
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputReader reader = new ConsoleInputReader();
            var input = reader.Read();

            IParser<MaterialReport> parser = new MaterialParser();
            var materials = parser.Parse(input);

            IMagazineService magazineService = new MagazineService();
            var magazines = magazineService.ProcessMaterialReportsIntoMagazines(materials).ToList();

            IWriter<IEnumerable<Magazine>> writer = new ConsoleWriter();
            writer.Write(magazines);
 
            Console.ReadLine();

        }
    }
}
