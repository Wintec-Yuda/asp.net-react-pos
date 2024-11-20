using PointOfSale.DTO.Request;
using PointOfSale.Models;

namespace PointOfSale.Services.Interfaces;

public interface ITransactionService
{
  Task CreateTransaction(TransactionRequetsDto transactionRequetsDto);
  Task<IEnumerable<Transaction>> GetTransactions();
  Task<Transaction?> GetTransactionById(Guid id);
}