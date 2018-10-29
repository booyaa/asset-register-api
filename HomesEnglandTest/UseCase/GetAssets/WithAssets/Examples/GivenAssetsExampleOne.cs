using HomesEngland.Domain;

namespace HomesEnglandTest.UseCase.GetAssets.WithAssets.Examples
{
    public class GivenAssetsExampleOne:GivenAssets
    {
        protected override int[] AssetsIds => new[] {1, 4123, 56, 34};
        protected override Asset[] AssetsToReturn { get; }

        public GivenAssetsExampleOne()
        {
            AssetsToReturn = CreateAssets(4);
        }
    }
}