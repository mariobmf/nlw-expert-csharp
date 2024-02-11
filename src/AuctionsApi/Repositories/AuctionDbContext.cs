using AuctionsApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionsApi;

public class AuctionDbContext : DbContext
{
  public DbSet<Auction> Auctions { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<Offer> Offers { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite("Data Source=/Users/mario/Projetos/Estudos/dotnet/Nlw/Auctions/src/AuctionsApi/auctions.db");
  }
}
