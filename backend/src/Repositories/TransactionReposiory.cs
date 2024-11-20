using Microsoft.EntityFrameworkCore;
using PointOfSale.Data;
using PointOfSale.DTO.Request;
using PointOfSale.Models;
using PointOfSale.Repositories.Interfaces;

namespace PointOfSale.Repositories;

public class TransactionRepository : ITransactionRepository
{
  private readonly AppDbContext _context;
  public TransactionRepository(AppDbContext context) => _context = context;

  public async Task CreateTransaction(TransactionRequetsDto transactionRequetsDto)
  {
    using (var transaction = await _context.Database.BeginTransactionAsync())
    {
      try
      {
        var transactionDto = new Transaction
        {
          UserId = transactionRequetsDto.UserId,
          TotalAmount = transactionRequetsDto.TotalAmount,
          Date = DateTime.Now
        };

        var newTransaction = _context.Transactions.Add(transactionDto);
        await _context.SaveChangesAsync();

        foreach (var item in transactionRequetsDto.transactionItems!)
        {
          var newTransactionItem = new TransactionItem
          {
            Quantity = item.Quantity,
            Price = item.Price,
            ProductId = item.ProductId,
            TransactionId = newTransaction.Entity.Id
          };
        }
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
      }
      catch (Exception)
      {
        await transaction.RollbackAsync();
        throw new Exception("Transaction failed");
      }
    }
  }

  public async Task<IEnumerable<Transaction>> GetTransactions()
  {
    return await _context.Transactions
    .Include(t => t.User)
    .Include(t => t.TransactionItems)
    .ToListAsync();
  }

  public async Task<Transaction?> GetTransactionById(Guid transactionId)
  {
    return await _context.Transactions
        .Include(t => t.User)
        .Include(t => t.TransactionItems)
        .FirstOrDefaultAsync(t => t.Id == transactionId);
  }
}