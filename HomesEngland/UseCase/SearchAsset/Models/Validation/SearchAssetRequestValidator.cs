using FluentValidation;

namespace HomesEngland.UseCase.GetAsset.Models.Validation
{
    public class SearchAssetRequestValidator : AbstractValidator<SearchAssetRequest>
    {
        public SearchAssetRequestValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Request must not be null");
            RuleFor(x => x.SchemeId).NotNull().GreaterThan(0).WithMessage("SchemeId must not be null and must be greater than 0.");
        }
    }
}
