using FluentValidation;

namespace HomesEngland.UseCase.SearchAsset.Models.Validation
{
    public class SearchAssetRequestValidator : AbstractValidator<SearchAssetRequest>
    {
        public SearchAssetRequestValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Request must not be null");
            RuleFor(x => x.SchemeId).NotNull().GreaterThan(0).When(w=> string.IsNullOrEmpty(w.Address)).WithMessage("SchemeId must not be null and must be greater than 0.");
            RuleFor(x => x.Address).NotNull().NotEmpty().When(w=> w.SchemeId.HasValue == false).WithMessage("Address must not be null or empty.");
        }
    }
}
