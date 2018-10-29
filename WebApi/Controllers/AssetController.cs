using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Exception;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    using Asset = Dictionary<string,string>;

    [Route("[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IGetAssetUseCase _assetUseCase;
        public AssetController(IGetAssetUseCase useCase)
        {
            _assetUseCase = useCase;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Asset>> Get(int id)
        {
            try
            {
                return await _assetUseCase.Execute(id);
            }
            catch (NoAssetException)
            {
                return new Asset();
            }
        }
    }
}
