using AuctionsApi.Entities;

namespace AuctionsApi.Contracts;

public interface IUserRepository
{
  bool ExistUserWithEmail(string email);
  User GetUserByEmail(string email);
}
