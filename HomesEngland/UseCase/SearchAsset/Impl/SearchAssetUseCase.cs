﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.SearchAsset.Models;
using Infrastructure.Api.Exceptions;

namespace HomesEngland.UseCase.SearchAsset.Impl
{
    public class SearchAssetUseCase : ISearchAssetUseCase
    {
        private readonly IAssetSearcher _assetSearcher;

        public SearchAssetUseCase(IAssetSearcher assetSearcher)
        {
            _assetSearcher = assetSearcher;
        }

        public async Task<SearchAssetResponse> ExecuteAsync(SearchAssetRequest request,
            CancellationToken cancellationToken)
        {
            ValidateRequest(request);

            var foundAssets = await SearchAssets(request, cancellationToken);

            var response = new SearchAssetResponse
            {
                Assets = foundAssets.Results?.Select(s => new AssetOutputModel(s)).ToList(),
                Pages = foundAssets.NumberOfPages,
                TotalCount = foundAssets.TotalCount
            };

            return response;
        }

        private async Task<IPagedResults<IAsset>> SearchAssets(SearchAssetRequest request, CancellationToken cancellationToken)
        {
            var assetSearch = new AssetPagedSearchQuery
            {
                SchemeId = request.SchemeId,
                Address = request.Address
            };

            if (request.Page != null) assetSearch.Page = request.Page;
            if (request.PageSize != null) assetSearch.PageSize = request.PageSize;

            var foundAssets = await _assetSearcher.Search(assetSearch, cancellationToken).ConfigureAwait(false);

            if (foundAssets == null)
                foundAssets = new PagedResults<IAsset>
                {
                    Results = new List<IAsset>(), 
                    NumberOfPages = 0, 
                    TotalCount = 0
                };

            return foundAssets;
        }

        private void ValidateRequest(SearchAssetRequest request)
        {
            if (request == null)
            {
                throw new BadRequestException();
            }

            var validationResponse = request.Validate(request);
            if (!validationResponse.IsValid)
            {
                throw new BadRequestException(validationResponse);
            }
        }
    }
}
