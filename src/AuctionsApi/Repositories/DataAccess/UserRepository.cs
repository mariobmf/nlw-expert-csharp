using AuctionsApi.Contracts;
using AuctionsApi.Entities;

namespace AuctionsApi.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
  private readonly AuctionDbContext _dbContext;
  public UserRepository(AuctionDbContext dbContext) => _dbContext = dbContext;

  public bool ExistUserWithEmail(string email) => _dbContext.Users.Any(user => user.Email.Equals(email));

  public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));
}
