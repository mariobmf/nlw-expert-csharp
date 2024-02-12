using AuctionsApi.Contracts;
using AuctionsApi.Entities;
using AuctionsApi.Enums;
using AuctionsApi.UseCases.Auctions.GetCurrent;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCasesTests.Auctions.GetCurrent;

public class GetCurrentAuctionUseCaseTest
{
  [Fact]
  public void Success()
  {
    var mockAuction = new Faker<Auction>()
      .RuleFor(auction => auction.Id, f => f.Random.Number(1, 700))
      .RuleFor(auction => auction.Name, f => f.Lorem.Word())
      .RuleFor(auction => auction.Starts, f => f.Date.Past())
      .RuleFor(auction => auction.Starts, f => f.Date.Future())
      .RuleFor(auction => auction.Items, (f, auction) =>
      [
        new Item
        {
          Id = f.Random.Number(1, 700),
          Name = f.Commerce.ProductName(),
          Brand = f.Commerce.Department(),
          BasePrice = f.Random.Decimal(50, 1000),
          Condition = f.PickRandom<Condition>(),
          AuctionId = auction.Id
        }
      ])
      .Generate();

    var mockAuctionRepository = new Mock<IAuctionRepository>();
    mockAuctionRepository.Setup(i => i.GetCurrent()).Returns(mockAuction);

    var useCase = new GetCurrentAuctionUseCase(mockAuctionRepository.Object);

    var auction = useCase.Execute();

    auction.Should().NotBeNull();
    auction.Id.Should().Be(mockAuction.Id);
    auction.Name.Should().Be(mockAuction.Name);
  }
}
