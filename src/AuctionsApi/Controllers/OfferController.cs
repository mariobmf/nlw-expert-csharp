using AuctionsApi.Communication.Requests;
using AuctionsApi.Filters;
using AuctionsApi.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AuctionsApi.Controllers;

[ServiceFilter(typeof(AuthenticationUserAtribute))]
public class OfferController : ApiBaseController
{
  [HttpPost]
  [Route("{itemId}")]
  public IActionResult CreateOffer(
    [FromRoute] int itemId,
    [FromBody] RequestCreateOfferJson request,
    [FromServices] CreateOfferUseCase useCase
  )
  {
    var id = useCase.Execute(itemId, request);
    return Created(string.Empty, id);
  }
}
