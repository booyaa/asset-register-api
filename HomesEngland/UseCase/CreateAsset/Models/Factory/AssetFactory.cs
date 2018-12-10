using System.Linq;
using HomesEngland.Domain.Factory;

namespace HomesEngland.UseCase.CreateAsset.Models.Factory
{
    public class CreateAssetRequestFactory:IFactory<CreateAssetRequest, CsvAsset>
    {
        public CreateAssetRequest Create(CsvAsset csvAsset)
        {
            if (csvAsset == null || string.IsNullOrEmpty(csvAsset.CsvLine) || string.IsNullOrWhiteSpace(csvAsset.CsvLine) || string.IsNullOrEmpty(csvAsset.Delimiter))
                return null;

            var fields = csvAsset?.CsvLine?.Split(csvAsset.Delimiter);
            int.TryParse(fields.ElementAtOrDefault(2), out var schemeId);
            int.TryParse(fields.ElementAtOrDefault(5), out var noOfBeds);
            var createAssetRequest = new CreateAssetRequest
            {
                Programme = fields.ElementAtOrDefault(0),
                EquityOwner = fields.ElementAtOrDefault(1),
                SchemeId = schemeId,
                LocationLaRegionName = fields.ElementAtOrDefault(3),
                ImsOldRegion = fields.ElementAtOrDefault(4),
                NoOfBeds = noOfBeds,
                Address = fields.ElementAtOrDefault(6),
            };
            return createAssetRequest;
        }
    }
}
