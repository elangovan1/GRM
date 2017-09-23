using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GRM.MusicContract.Music.Provider.Data;
using NUnit.Framework;
using GRM.MusicContract.Music.Provider.Stream;
using Moq;

namespace GRM.MusicContract.Music.Tests.Provider.Stream
{
    public class MusicTests
    {
        private Mock<ITextReader> mockTextReader;
        private MusicStream musicDataProvider;

        [SetUp]
        public void Setup()
        {
            mockTextReader = new Mock<ITextReader>();
            musicDataProvider = new MusicStream(mockTextReader.Object);
        }

        [Test]
        public void WhenGetContractIsCalled_ThenTheContractDetailsShoudReturnWithSortOrderByArtistAndTitle()
        { 
            var contracts = new List<string>();
            
            contracts.Add("Tinie Tempah|Frisky (Live from SoHo)|digital download, streaming|1st Feb 2012|");
            contracts.Add("Monkey Claw|Motor Mouth|digital download, streaming| 1st Mar 2011|");
            contracts.Add("Monkey Claw|Christmas Special|streaming|25st Dec 2012|31st Dec 2012");

            mockTextReader.Setup(method => method.ReadData(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(contracts);

            var contract = musicDataProvider.GetContract();

            contract.Should().NotBeNullOrEmpty();
            contract.Count().Should().Be(3);

            var result = contract.ToList();
            
            result[0].Artist.Should().Be("Monkey Claw");
            result[0].Title.Should().Be("Christmas Special");

            result[1].Artist.Should().Be("Monkey Claw");
            result[1].Title.Should().Be("Motor Mouth");
            
            result[2].Artist.Should().Be("Tinie Tempah");
            result[2].Title.Should().Be("Frisky (Live from SoHo)");


            mockTextReader.Verify(method => method.ReadData(It.IsAny<string>(), It.IsAny<bool>()), Times.Exactly(1));
        }

        [Test]
        public void WhenGetPartnerIsCalled_ThenThePartnerDetailsShoudReturn()
        {
            var partner = new List<string>();
            partner.Add("Partner|Usage");
            partner.Add("ITunes|digital download");

            mockTextReader.Setup(method => method.ReadData(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(partner);

            var result = musicDataProvider.GetPartner();

            result.Should().NotBeNullOrEmpty();
            result.Count().Should().Be(2);

            mockTextReader.Verify(method => method.ReadData(It.IsAny<string>(), It.IsAny<bool>()), Times.Exactly(1));
        }
    }
}
