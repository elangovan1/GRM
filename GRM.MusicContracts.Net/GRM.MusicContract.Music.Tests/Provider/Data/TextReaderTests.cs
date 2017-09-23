using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GRM.MusicContract.Music.Provider.Data;
using NUnit.Framework;

namespace GRM.MusicContract.Music.Tests.Provider.Data
{
    public class TextReaderTests
    {
        public class MusicTests
        {

            [Test]
            public void WhenReadDataIsCalledWithInvalidArgument_ThenShoudReturnError()
            {
                Action result = () => new TextReader().ReadData("InvalidResourceName", false);

                result.ShouldThrow<KeyNotFoundException>();
            }
            
            [Test]
            public void WhenReadDataIsCalled_ThenReadedDataShoudReturn()
            {
                var contracts = new TextReader().ReadData("MusicContract", true);

                contracts.Should().NotBeNullOrEmpty();
                contracts.Count().Should().Be(7);
            }
        }
    }
}
