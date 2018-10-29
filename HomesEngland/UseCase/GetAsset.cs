using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.Boundary;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;
using HomesEngland.Exception;

namespace HomesEngland.UseCase
{
    public class GetAsset :IGetAssetUseCase
    {
        private IAssetGateway Gateway { get; }
        public GetAsset(IAssetGateway gateway)
        {
            Gateway = gateway;
        }
        public async Task<Dictionary<string,string>> Execute(int id)
        {
            Asset asset = await Gateway.GetAsset(id);
            if (asset == null)
            {
                throw new NoAssetException();
            }
            return asset.ToDictionary();
        }
    }
}