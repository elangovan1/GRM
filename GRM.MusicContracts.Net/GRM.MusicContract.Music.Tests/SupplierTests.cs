using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GRM.MusicContract.Music.Entity;
using GRM.MusicContract.Music.Provider.Stream;
using Moq;
using NUnit.Framework;

namespace GRM.MusicContract.Music.Tests
{
    public class SupplierTests
    {
        private Mock<IMusicStream> mockMusicStream;

        [SetUp]
        public void Setup()
        {
            mockMusicStream = new Mock<IMusicStream>();
        }

        [Test]
        public void WhenInvalidSupplierReferenceIsGiven_ThenShouldReturnArgumentException()
        {
            var supplier = new Supplier(mockMusicStream.Object);
            Action result = () => supplier.Get("");
            result.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void WhenValidSupplierReferenceIsGiven_ThenShouldReturnSupplierDetails()
        {
            var supplier = new Supplier(mockMusicStream.Object);
            var partners = new List<Partner>();
            var contracts = new List<Contract>();

            partners.Add(new Partner
            {
                Name = "ITunes",
                Usage = "digital download"
            });

            contracts.Add(
                new Contract
                {
                    Artist = "Tinie Tempah",
                    Title = "Frisky (Live from SoHo)",
                    Usages = new List<string> { "digital download" },
                    StartDate = "1st March 2012"
                }
            );
            
            mockMusicStream.Setup(method => method.GetContract()).Returns(contracts);

            mockMusicStream.Setup(method => method.GetPartner()).Returns(partners);
            
            var result = supplier.Get("ITunes 1st March 2012");

            result.Should().NotBeNullOrEmpty();
            result.ToList().Count().Should().Be(2);
            result.ToList().LastOrDefault().Should().Be("Tinie Tempah|Frisky (Live from SoHo)|digital download|1st March 2012|");

            mockMusicStream.Verify(method => method.GetContract(), Times.Exactly(1));
            mockMusicStream.Verify(method => method.GetPartner(), Times.Exactly(1));
        }
    }
}
