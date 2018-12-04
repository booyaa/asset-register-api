using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Api.Response.Formatters;
using NUnit.Framework;

namespace InfrastructureTest.Api.Formatters
{
    [TestFixture]
    public class CsvFormatterTest
    {
        private CsvFormatter _classUnderTest;
        [SetUp]
        public void Setup()
        {
            _classUnderTest = new CsvFormatter();
        }

        [Test]
        public async Task GivenSingleAsset_WhenOutputting()
        {
            //arrange

            //act
            _classUnderTest.
            //assert
        }
    }
}
