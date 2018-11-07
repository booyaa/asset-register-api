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
    public class SearchController : Controller
    {
        private ISearchAssets UseCase { get; }
        public SearchController(ISearchAssets useCase)
        {
            UseCase = useCase;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AssetsDictionary), 200)]
        public async Task<ActionResult<AssetsDictionary>> Get(string query)
        {
            return GetWrappedAssets(await UseCase.Execute(query));
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
