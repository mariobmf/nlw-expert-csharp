using AuctionsApi.Communication.Requests;
using AuctionsApi.Entities;
using AuctionsApi.Services;

namespace AuctionsApi.UseCases;

public class CreateOfferUseCase
{
  private readonly LoggedUser _loggedUser;
  public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;

  public int Execute(int itemId, RequestCreateOfferJson request)
  {
    var repository = new AuctionDbContext();
    var user = _loggedUser.User();
    var offer = new Offer
    {
      CreatedOn = DateTime.Now,
      ItemId = itemId,
      Price = request.Price,
      UserId = user.Id
    };
    repository.Offers.Add(offer);
    repository.SaveChanges();
    return offer.Id;
  }
}