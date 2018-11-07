using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Exception;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    using Asset = Dictionary<string,string>;

    [ApiVersion("1")]
    [Route("[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IGetAsset _asset;
        public AssetController(IGetAsset useCase)
        {
            _asset = useCase;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Asset>> Get(int id)
        {
            try
            {
                return await _asset.Execute(id);
            }
            catch (NoAssetException)
            {
                return new Asset();
            }
        }
    }
}
