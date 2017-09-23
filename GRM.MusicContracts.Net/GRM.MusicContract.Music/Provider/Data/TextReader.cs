using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using GRM.MusicContract.Music.Properties;
using GRM.MusicContract.Music.Utility;

namespace GRM.MusicContract.Music.Provider.Data
{
    public class TextReader : ITextReader
    {
        public IEnumerable<string> ReadData(string resourceName, bool ignoreTitle)
        {
            var myManager = new ResourceManager(typeof(Resources));
            var resourceData = myManager.GetString(resourceName);

            Guard.KeyNotFoundException(resourceData, nameof(resourceData));

            var data = resourceData.Split(new[] {Environment.NewLine}, 
                StringSplitOptions.RemoveEmptyEntries).ToList();

            if (ignoreTitle)
            {
                data.RemoveAt(0);
            }

            return data;
        }
    }
}
