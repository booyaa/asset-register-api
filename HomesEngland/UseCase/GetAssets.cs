using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomesEngland.Boundary;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;
using HomesEngland.Exception;

namespace HomesEngland.UseCase
{
    public class GetAssets:IGetAssetsUseCase
    {
        private IAssetGateway Gateway { get; }
        public GetAssets(IAssetGateway gateway)
        {
            Gateway = gateway;
        }

        public async Task<Dictionary<string,string>[]> Execute(int[] id)
        {
            Asset[] assets = await Gateway.GetAssets(id);
            if (assets == null)
            {
                throw new NoAssetException();
            }
            return assets.Select(_ => _.ToDictionary()).ToArray();
        }
    }
}