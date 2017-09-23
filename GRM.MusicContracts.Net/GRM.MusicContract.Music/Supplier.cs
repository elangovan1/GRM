using System;
using System.Collections.Generic;
using System.Linq;
using GRM.MusicContract.Music.Provider.Stream;
using GRM.MusicContract.Music.Utility;

namespace GRM.MusicContract.Music
{
    public class Supplier
    {
        private readonly IMusicStream _musicStream;

        public Supplier(IMusicStream musicStream)
        {
            _musicStream = musicStream;
        }

        public IEnumerable<string> Get(string reference)
        {
            var results = new List<string>();
            Guard.ArgumentIsNotNullOrEmpty(reference, nameof(reference));

            var references = References(reference);

            var contracts = _musicStream.GetContract();
            var partners = _musicStream.GetPartner();

            if (!contracts.Any())
                return results;

            AddOutputTitle(results);
            
            var activeContracts = contracts.Where(contDate => DateParser.GetDate(contDate.StartDate) <= DateParser.GetDate(references[1]));

            foreach (var contract in activeContracts)
            {
                results.AddRange(from usage in partners
                                 where usage.Name.ToLower() == references[0].ToLower()
                                 && contract.Usages.ToList().Any(con => con.IndexOf(usage.Usage) >= 0)
                                 select $"{contract.Artist}|{contract.Title}|{usage.Usage}|{contract.StartDate}" +
                                        $"|{contract.EndDate}");
            }

            return results;
        }

        private static void AddOutputTitle(List<string> results)
        {
            results.Add("Artist|Title|Usage|StartDate|EndDate");
        }

        private static string[] References(string reference)
        {
            var references = reference.Split(new[] { ' ' }, 2);

            if (references.Length > 2 || references.Length < 2)
                throw new ArgumentOutOfRangeException();

            return references;
        }
    }
}