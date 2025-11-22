using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.DTOs 
{
  public record TransactionCreateDto(decimal Amount, TransactionType Type, string CategoryId, DateTime Date, string? Description);
}
