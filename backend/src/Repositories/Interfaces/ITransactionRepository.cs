using PointOfSale.DTO.Request;
using PointOfSale.Models;

namespace PointOfSale.Repositories.Interfaces;

public interface ITransactionRepository
{
  Task CreateTransaction(TransactionRequetsDto transactionRequetsDto);
  Task<IEnumerable<Transaction>> GetTransactions();
  Task<Transaction?> GetTransactionById(Guid transactionId);
}