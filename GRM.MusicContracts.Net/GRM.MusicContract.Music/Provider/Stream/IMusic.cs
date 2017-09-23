using System.Collections.Generic;
using GRM.MusicContract.Music.Entity;

namespace GRM.MusicContract.Music.Provider.Stream
{
    public interface IMusicStream
    {
        IEnumerable<Contract> GetContract();
        IEnumerable<Partner> GetPartner();
    }
}