using AuctionsApi.Entities;

namespace AuctionsApi.Contracts;

public interface IAuctionRepository
{
  Auction? GetCurrent();
}