using HomesEngland.UseCase.Models;

namespace HomesEngland.UseCase.GetAsset.Models
{
    public class GetAssetRequest:IRequest
    {
        public int? Id { get; set; }
    }
}
