using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.Boundary.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    using AssetsDictionary = Dictionary<string, Dictionary<string, string>[]>;

    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IGetAssets _assets;
        public AssetsController(IGetAssets useCase)
        {
            _assets = useCase;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AssetsDictionary), 200)]
        public async Task<ActionResult<AssetsDictionary>> Get(int[] ids)
        {
            return GetWrappedAssets( await _assets.Execute(ids));
        }

        private static AssetsDictionary GetWrappedAssets(Dictionary<string, string>[] results)
        {
            return new AssetsDictionary
            {
                {
                    "Assets", results
                }
            };
        }
    }
}
