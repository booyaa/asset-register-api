using FluentValidation;
using HomesEngland.UseCase.GenerateAssets.Models;

namespace HomesEngland.Gateway.DataGenerator
{
    public class GenerateAssetsRequestValidator : AbstractValidator<GenerateAssetsRequest>
    {
        public GenerateAssetsRequestValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Request must not be null");
            RuleFor(x => x.Records).NotNull().GreaterThan(0).WithMessage("Records must not be null and must be greater than 0.");
        }
    }
}
