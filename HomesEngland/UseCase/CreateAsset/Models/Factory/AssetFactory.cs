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
            var createAssetRequest = new CreateAssetRequest
            {
                Address = fields.ElementAtOrDefault(6),
            };
            return createAssetRequest;
        }
    }
}
