using System.Collections.Generic;
using System.Linq;
using GRM.MusicContract.Music.Entity;
using GRM.MusicContract.Music.Provider.Data;

namespace GRM.MusicContract.Music.Provider.Stream
{
    public class MusicStream : IMusicStream
    {
        private readonly ITextReader _textReader;

        public MusicStream(ITextReader textReader)
        {
            _textReader = textReader;
        }

        public IEnumerable<Contract> GetContract()
        {
           var contracts = _textReader.ReadData("MusicContract", true);

           var result = new List<Contract>();

            foreach (var data in contracts)
            {
                var parts = data.Split('|');
                result.Add(new Contract
                {
                    Artist = parts[0].Trim(),
                    Title = parts[1].Trim(),
                    Usages = parts[2].Split(',').ToList(),
                    StartDate = parts[3],
                    EndDate = parts[4]
                });
            }
            //result.Sort();

            result.Sort(delegate (Contract a, Contract b)
            {
                int diff = a.Artist.CompareTo(b.Artist);

                if (diff != 0) { return diff;}
                else
                { return a.Title.CompareTo(b.Title);}
            });

            return result;
        }

        public IEnumerable<Partner> GetPartner()
        {
            var partners = _textReader.ReadData("Partner", true);

            var result = new List<Partner>();

            foreach (var data in partners)
            {
                var parts = data.Split('|');
                result.Add(new Partner
                {
                    Name = parts[0].Trim(),
                    Usage = parts[1].Trim()
                });
            }

            return result;
        }
    }
}
