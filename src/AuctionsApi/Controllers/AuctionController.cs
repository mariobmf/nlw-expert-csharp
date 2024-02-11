using AuctionsApi.Entities;
using AuctionsApi.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace AuctionsApi.Controllers;

public class AuctionController : ApiBaseController
{
  [HttpGet]
  [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult GetCurrentAction()
  {
    var useCase = new GetCurrentAuctionUseCase();
    var result = useCase.Execute();

    if (result is null)
      return NoContent();

    return Ok(result);
  }
}
