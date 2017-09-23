using System.Collections.Generic;

namespace GRM.MusicContract.Music.Provider.Data
{
    public interface ITextReader
    {
        IEnumerable<string> ReadData(string filePath, bool ignoreTitle);
    }
}