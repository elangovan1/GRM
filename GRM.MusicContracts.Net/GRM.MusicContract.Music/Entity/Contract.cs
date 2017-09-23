using System;
using System.Collections.Generic;

namespace GRM.MusicContract.Music.Entity
{
    public class Contract : IComparable<Contract>
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Usages { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        
        public int CompareTo(Contract contract)
        {
            return Artist.CompareTo(contract.Artist);
        }
    }
}
