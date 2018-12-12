using System.Collections.Generic;

namespace HomesEngland.UseCase.ImportAssets
{
    public interface ITextSplitter
    {
        IList<string> SplitIntoLines(string text);
    }
}
