using System;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;

namespace HomesEngland.Gateway.Impl
{
    public class InMemoryAssetReader:IAssetReader
    {
        public Task<Asset> ReadAsync(int index)
        {
            throw new NotImplementedException();
        }
    }
}
