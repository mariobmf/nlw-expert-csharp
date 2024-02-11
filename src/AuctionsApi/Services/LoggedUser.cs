using AuctionsApi.Entities;

namespace AuctionsApi.Services;

public class LoggedUser
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public LoggedUser(IHttpContextAccessor httpContext)
  {
    _httpContextAccessor = httpContext;
  }

  public User User()
  {
    var repository = new AuctionDbContext();

    var token = TokenOnRequest();
    var email = FromBase64String(token);

    return repository.Users.First(user => user.Email.Equals(email));
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
