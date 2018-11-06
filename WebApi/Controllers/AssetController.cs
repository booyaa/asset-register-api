using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Exception;
using Infrastructure.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    using Asset = Dictionary<string, string>;

    [Route("api/[controller]")]
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
        public async Task<ActionResult<ApiResponse<Asset>>> Get(int id)
        {
            var result = await _asset.Execute(id).ConfigureAwait(false);
            return new ApiResponse<Asset>(result);
        }
    }
}
