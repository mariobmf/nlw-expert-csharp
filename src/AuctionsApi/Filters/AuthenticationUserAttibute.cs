using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuctionsApi.Filters;

public class AuthenticationUserAtribute : AuthorizeAttribute, IAuthorizationFilter
{
  public void OnAuthorization(AuthorizationFilterContext context)
  {
    try
    {
      var token = TokenOnRequest(context.HttpContext);
      var repository = new AuctionDbContext();
      var email = FromBase64String(token);
      var userExist = repository.Users.Any(user => user.Email.Equals(email));
      if (!userExist)
        context.Result = new UnauthorizedObjectResult("E-mail not valid!");

    }
    catch (Exception ex)
    {
      context.Result = new UnauthorizedObjectResult(ex.Message);
    }
  }

  private string TokenOnRequest(HttpContext context)
  {
    var authentication = context.Request.Headers.Authorization.ToString();

    if (string.IsNullOrEmpty(authentication))
      throw new Exception("Token not found");

    return authentication.Split(" ")[1];
  }

  private string FromBase64String(string base64)
  {
    var base64EncodedBytes = Convert.FromBase64String(base64);
    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
  }
}