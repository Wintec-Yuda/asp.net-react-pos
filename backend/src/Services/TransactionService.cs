using PointOfSale.DTO.Request;
using PointOfSale.Models;
using PointOfSale.Repositories.Interfaces;
using PointOfSale.Services.Interfaces;

namespace PointOfSale.Services;

public class TransactionService : ITransactionService
{
  private readonly ITransactionRepository _transactionRepository;

  public TransactionService(ITransactionRepository transactionRepository) => _transactionRepository = transactionRepository;

  public async Task CreateTransaction(TransactionRequetsDto transactionRequetsDto)
  {
    try
    {
      await _transactionRepository.CreateTransaction(transactionRequetsDto);
    }
    catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }

  public async Task<IEnumerable<Transaction>> GetTransactions() 
  {
    return await _transactionRepository.GetTransactions();
  }

  public async Task<Transaction?> GetTransactionById(Guid transactionId)
  {
    return await _transactionRepository.GetTransactionById(transactionId);
  }
}