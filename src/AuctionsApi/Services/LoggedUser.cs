using AuctionsApi.Contracts;
using AuctionsApi.Entities;

namespace AuctionsApi.Services;

public class LoggedUser : ILoggedUser
{
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IUserRepository _userRepository;

  public LoggedUser(IHttpContextAccessor httpContext, IUserRepository userRepository)
  {
    _httpContextAccessor = httpContext;
    _userRepository = userRepository;
  }

  public User User()
  {
    var token = TokenOnRequest();
    var email = FromBase64String(token);

    return _userRepository.GetUserByEmail(email);
  }

  private string TokenOnRequest()
  {
    var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

    return authentication.Split(" ")[1];
  }

  private string FromBase64String(string token)
  {
    var base64EncodedBytes = Convert.FromBase64String(token);

    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
  }
}
