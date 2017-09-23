using System;
using FluentAssertions;
using GRM.MusicContract.Music.Utility;
using NUnit.Framework;

namespace GRM.MusicContract.Music.Tests.Utility
{
    public class DateParserTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void WhenInvalidDateStringIsGiven_ThenShouldThrowInvalidArgumentException(string input)
        {
            Action result = () => DateParser.GetDate(input);

            result.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void WhenInvalidValidDateStringIsGiven_ThenShouldErrorMessage()
        {
            Action result = () => DateParser.GetDate("InvalidDateString");

            result.ShouldThrow<FormatException>().WithMessage("String was not recognized as a valid DateTime.");
        }


        [Test]
        public void WhenInvalidValidFormatDateStringIsGiven_ThenShouldErrorMessage()
        {
            Action result = () => DateParser.GetDate("March 2012");

            result.ShouldThrow<FormatException>().WithMessage("String was not recognized as a valid DateTime.");
        }

        [Test]
        [TestCase("1st March 2012", 3, 1)]
        [TestCase("1st Feb 2012", 2, 1)]
        [TestCase("2nd March 2012", 3, 2)]
        [TestCase("2nd Feb 2012", 2, 2)]
        [TestCase("20th March 2012", 3, 20)]
        [TestCase("20th Feb 2012", 2, 20)]
        public void WhenValidValidDateStringIsGiven_ThenShouldValidDateTime(string input, int outputMonth, int outputDay)
        {
            var result = DateParser.GetDate(input);

            result.Should().HaveYear(2012);
            result.Should().HaveMonth(outputMonth);
            result.Should().HaveDay(outputDay);
        }
    }
}
