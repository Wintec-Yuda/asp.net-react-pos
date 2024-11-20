using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.DTO.Request;
using PointOfSale.Services.Interfaces;

namespace PointOfSale.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
  private readonly ITransactionService _transactionService;

  public TransactionController(ITransactionService transactionService) => _transactionService = transactionService;

  [HttpPost()]
  [Authorize(Roles = "USER")]
  public async Task<IActionResult> CreateTransaction([FromBody] TransactionRequetsDto transactionRequetsDto)
  {
    try
    {
      await _transactionService.CreateTransaction(transactionRequetsDto);
      return StatusCode(201, new
      {
        message = "Create transaction successfully"
      });
    }
    catch (Exception e)
    {
      return StatusCode(500, new
      {
        message = e.Message
      });
    }
  }

  [HttpGet()]
  [Authorize(Roles = "ADMIN")]
  public async Task<IActionResult> GetTransactions()
  {
    try
    {
      var transactions = await _transactionService.GetTransactions();
      return Ok(new
      {
        message = "Get all transactions successfully",
        data = transactions
      });
    }
    catch (Exception e)
    {
      return StatusCode(500, new
      {
        message = e.Message
      });
    }
  }

  [HttpGet("{transactionId}")]
  [Authorize(Roles = "ADMIN")]
  public async Task<IActionResult> GetTransactionById([FromBody] Guid transactionId)
  {
    try
    {
      var transaction = await _transactionService.GetTransactionById(transactionId);
      return Ok(new
      {
        message = "Get transaction by id successfully",
        data = transaction
      });
    }
    catch (Exception e)
    {
      return StatusCode(500, new
      {
        message = e.Message
      });
    }
  }
}