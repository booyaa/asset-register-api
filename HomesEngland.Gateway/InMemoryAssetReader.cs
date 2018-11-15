using System;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;

namespace HomesEngland.Gateway
{
    public class InMemoryAssetReader:IAssetReader
    {
        public Task<IAsset> ReadAsync(int index)
        {
            throw new NotImplementedException();
        }
    }
}
