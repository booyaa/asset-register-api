using System;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;

namespace HomesEngland.Gateway.InMemory
{
    public class InMemoryAssetReader : IAssetReader
    {
        class InMemoryAsset : IAsset
        {
            public int Id { get; set; }
            public DateTime ModifiedDateTime { get; set; }
            public string MonthPaid { get; set; }
            public string AccountingYear { get; set; }
            public int? SchemeId { get; set; }
            public string LocationLaRegionName { get; set; }
            public string ImsOldRegion { get; set; }
            public string NoOfBeds { get; set; }
            public string Address { get; set; }
            public string DevelopingRslName { get; set; }
            public DateTime? CompletionDateForHpiStart { get; set; }
            public DateTime? ImsActualCompletionDate { get; set; }
            public DateTime? ImsExpectedCompletionDate { get; set; }
            public DateTime? ImsLegalCompletionDate { get; set; }
            public DateTime? HopCompletionDate { get; set; }
            public decimal? Deposit { get; set; }
            public decimal? AgencyEquityLoan { get; set; }
            public decimal? DeveloperEquityLoan { get; set; }
            public decimal? ShareOfRestrictedEquity { get; set; }
            public int? DifferenceFromImsExpectedCompletionToHopCompletionDate { get; set; }
        }

        public Task<IAsset> ReadAsync(int index)
        {
            IAsset asset = new InMemoryAsset();
            asset.Id = 1;
            asset.ModifiedDateTime = DateTime.Now;
            asset.MonthPaid = "Jan";
            asset.AccountingYear = "2018";
            asset.SchemeId = 10101;
            asset.LocationLaRegionName = "Yorkshire";
            asset.ImsOldRegion = "Cat";
            asset.NoOfBeds = "1";
            asset.Address = "123 Cat Street";
            asset.DevelopingRslName = "Meowmeow";
            asset.CompletionDateForHpiStart = DateTime.Now;
            asset.ImsActualCompletionDate = DateTime.Now;
            asset.ImsExpectedCompletionDate = DateTime.Now;
            asset.ImsLegalCompletionDate = DateTime.Now;
            asset.HopCompletionDate = DateTime.Now;
            asset.Deposit = 1234;
            asset.AgencyEquityLoan = 1235;
            asset.DeveloperEquityLoan = 1236;
            asset.ShareOfRestrictedEquity = 1236;
            asset.DifferenceFromImsExpectedCompletionToHopCompletionDate = 1238;

            return Task.FromResult(asset);
        }
    }
}
