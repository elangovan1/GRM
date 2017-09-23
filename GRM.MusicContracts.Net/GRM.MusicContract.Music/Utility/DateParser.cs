using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GRM.MusicContract.Music.Utility
{
    public static class DateParser 
    {
        public static DateTime GetDate(string dateString)
        {
            Guard.ArgumentIsNotNullOrEmpty(dateString, nameof(dateString));

            var dateValues = dateString.Split(' ');

            if(dateValues.Length != 3)
                throw new FormatException("String was not recognized as a valid DateTime.");
          
            var day = int.Parse(Regex.Match(dateValues[0], @"\d+").Value);

            var months = from m in Enumerable.Range(1, 12)
                        select new
                        {
                            Value = m,
                            Text = (new DateTime(2017, m, 1)).ToString("MMMM"),
                        };

            var month = months.Single(currentMonth => currentMonth.Text.StartsWith(dateValues[1])).Value;

            var year = int.Parse(dateValues[2]);

            return new DateTime(year, month, day);
        }
         
    }
}
