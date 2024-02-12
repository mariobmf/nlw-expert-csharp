using AuctionsApi.Entities;

namespace AuctionsApi.Contracts;

public interface IOfferRepository
{
  void Add(Offer offer);
}
