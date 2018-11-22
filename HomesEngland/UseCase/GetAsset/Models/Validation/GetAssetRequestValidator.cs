using FluentValidation;

namespace HomesEngland.UseCase.GetAsset.Models.Validation
{
    public class GetAssetRequestValidator : AbstractValidator<GetAssetRequest>
    {
        public GetAssetRequestValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Request must not be null");
            RuleFor(x => x.Id).NotNull().GreaterThan(0).WithMessage("Id must not be null and must be greater than 0.");
        }
    }
}
