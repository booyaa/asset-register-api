using System.ComponentModel.DataAnnotations.Schema;
using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public class DapperAssetAggregation:IAssetAggregation
    {
        [Column("UniqueRecords")]
        public decimal? UniqueRecords { get; set; }
        [Column("MoneyPaidOut")]
        public decimal? MoneyPaidOut { get; set; }
        [Column("AssetValue")]
        public decimal? AssetValue { get; set; }
        [Column("MovementInAssetValue")]
        public decimal? MovementInAssetValue { get; set; }
    }
}
