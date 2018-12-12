using System.Threading;
using System.Threading.Tasks;

namespace HomesEngland.UseCase.ImportAssets
{
    public interface IFileReader<T>
    {
        Task<T> ReadAsync(string absoluteFilePath, CancellationToken cancellationToken);
    }
}
