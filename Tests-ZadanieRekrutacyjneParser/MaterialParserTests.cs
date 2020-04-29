using NUnit.Framework;
using ZadanieRekrutacyjneParser;
using System.Linq;
using System;

namespace Tests_ZadanieRekrutacyjneParser
{
    public class Tests
    {
        MaterialParser parser; 
        [SetUp]
        public void Setup()
        {
            parser = new MaterialParser();
        }

        [TearDown]
        public void Teardown()
        {
            parser = null; 
        }

        [Test]
        public void Parse_EmptyInput()
        {
            string input = @"";
            var output = parser.Parse(input);

            Assert.IsNull(output);
        }

        [Test]
        public void Parse_NullInput()
        {
            string input = null;
            var output = parser.Parse(input);

            Assert.IsNull(output);
        }


        [Test]
        public void Parse_WhiteSpaceInput()
        {
            string input = @"     ";
            var output = parser.Parse(input);

            Assert.IsNull(output);
        }


        [Test]
        public void Parse_OnlyComments()
        {
            string input = @"#comment
#comment
#comment";
            var output = parser.Parse(input);

            Assert.IsNotNull(output);
            Assert.IsFalse(output.Any());
        }

        [Test]
        public void Parse()
        {
            string input = @"Cherry Hardwood Arched Door - PS;COM-100001;WH-A,5";
            var output = parser.Parse(input);

            Assert.IsNotNull(output);
            Assert.AreEqual(1, output.Count());
        }

        [Test]
        public void Parse_ParsingExceptionInt32Parse()
        {
            string input = @"Cherry Hardwood Arched Door - PS;COM-100001;WH-A,maklsdmlksmd";
            
            FormatException ex = Assert.Throws<FormatException>(() => parser.Parse(input));
        }

        public void Parse_ParsingExceptionArrayOutOfBounds()
        {
            string input = @"Cherry Hardwood Arched Door - PS;";
            
            IndexOutOfRangeException ex = Assert.Throws<IndexOutOfRangeException>(() => parser.Parse(input));

        }
    }
}