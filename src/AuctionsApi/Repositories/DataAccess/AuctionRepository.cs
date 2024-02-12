using AuctionsApi.Contracts;
using AuctionsApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionsApi.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
  private readonly AuctionDbContext _dbContext;
  public AuctionRepository(AuctionDbContext dbContext) => _dbContext = dbContext;

  public Auction? GetCurrent()
  {
    var today = DateTime.Now;

    return _dbContext.Auctions
      .Include(auction => auction.Items)
      .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
  }
}