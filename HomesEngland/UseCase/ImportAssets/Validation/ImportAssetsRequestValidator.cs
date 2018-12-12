using FluentValidation;
using HomesEngland.UseCase.ImportAssets.Models;

namespace HomesEngland.UseCase.ImportAssets.Validation
{
    public class ImportAssetsRequestValidator : AbstractValidator<ImportAssetsRequest>
    {
        public ImportAssetsRequestValidator()
        {
            RuleFor(r => r.AssetLines).NotNull().NotEmpty();
            RuleFor(r => r.Delimiter).NotNull().NotEmpty();
        }
    }
}
