using MoneyTracker.Domain.Entities;
using MoneyTracker.Domain.Enums;
using MoneyTracker.Application.DTOs;

namespace MoneyTracker.Application.Services.Interfaces
{
  public interface ITransactionService
  {
    Task<Transaction> CreateAsync(decimal amount, TransactionType type, string category, DateTime date, string? desc);
    Task UpdateAsync(Guid id, decimal amount, TransactionType type, string category, DateTime date, string? desc);
    Task DeleteAsync(Guid id);
    Task<Transaction?> GetByIdAsync(Guid id);
    Task<IEnumerable<Transaction>> ListAsync(TransactionQueryDto dto);
    Task<IEnumerable<Transaction>> ListByMonthAsync(int year, int month);
  }
}