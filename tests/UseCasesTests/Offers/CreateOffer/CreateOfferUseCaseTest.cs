using AuctionsApi.Communication.Requests;
using AuctionsApi.Contracts;
using AuctionsApi.Entities;
using AuctionsApi.Services;
using AuctionsApi.UseCases.Offers.CreateOffer;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCasesTests.Offers.CreateOffer;

public class CreateOfferUseCaseTest
{
  [Theory]
  [InlineData(1)]
  [InlineData(2)]
  [InlineData(3)]
  public void Success(int itemId)
  {
    var request = new Faker<RequestCreateOfferJson>()
      .RuleFor(request => request.Price, f => f.Random.Decimal(50, 1000))
      .Generate();

    var mockOfferRepository = new Mock<IOfferRepository>();
    var mockLoggedUser = new Mock<ILoggedUser>();
    mockLoggedUser.Setup(i => i.User()).Returns(new User());

    var useCase = new CreateOfferUseCase(mockLoggedUser.Object, mockOfferRepository.Object);

    var act = () => useCase.Execute(itemId, request);

    act.Should().NotThrow();
  }
}
