using MoneyTracker.Application.DTOs;
using MoneyTracker.Domain.Queries;

namespace MoneyTracker.Application.Mappers
{
  public static class TransactionQueryMapper
  {
      public static TransactionQuery ToQuery(this TransactionQueryDto dto)
      {
          return new TransactionQuery
          {
              Type = dto.Type,
              CategoryId = dto.CategoryId,
              From = dto.From,
              To = dto.To,
              Page = dto.Page,
              PageSize = dto.PageSize
          };
      }
  }
}