using AuctionsApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionsApi.Repositories;

public class AuctionDbContext : DbContext
{
  public AuctionDbContext(DbContextOptions options) : base(options) { }
  public DbSet<Auction> Auctions { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<Offer> Offers { get; set; }
}
