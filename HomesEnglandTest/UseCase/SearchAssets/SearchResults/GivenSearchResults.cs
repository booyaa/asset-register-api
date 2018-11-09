using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.SearchAssets.SearchResults
{
    public abstract class GivenSearchResults:SearchAssetsTest
    {
        [Test]
        public void ItReturnsTheCorrectNumberOfDictionaries()
        {
            Assert.IsNotNull(SearchResults);
            Assert.True(SearchResults.Length == GatewaySearchResults.Length);
        }

        [Test]
        public void DictionariesContainAssetData()
        {
            SearchResults.ToList().ForEach(CheckSearchResult);
        }

        private void CheckSearchResult(Dictionary<string, string> searchResult)
        {
            string address = searchResult["Address"];
            string accountingYear = searchResult["AccountingYear"];
            string schemeId = searchResult["SchemeID"];

            Assert.True(GatewaySearchResults.Any(_ => _.Address == address));
            Assert.True(GatewaySearchResults.Any(_ => _.AccountingYear == int.Parse(accountingYear)));
            Assert.True(GatewaySearchResults.Any(_ => _.SchemeId == int.Parse(schemeId)));
        }
    }
}