using MoneyTracker.Domain.Entities;
using MoneyTracker.Domain.Interfaces;
using MoneyTracker.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyTracker.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MoneyTrackerDbContext _db;

        public TransactionRepository(MoneyTrackerDbContext db) => _db = db;

        public async Task AddAsync(Transaction transaction)
        {
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var t = await _db.Transactions.FindAsync(id);
            if (t != null) { _db.Transactions.Remove(t); await _db.SaveChangesAsync(); }
        }

        public async Task<Transaction?> GetByIdAsync(Guid id) => await _db.Transactions.FindAsync(id);

        public async Task<IEnumerable<Transaction>> ListAsync(TransactionQuery query)
        {
            var q = _db.Transactions.AsQueryable();

            if (query.Type.HasValue)
                q = q.Where(t => t.Type == query.Type.Value);

            if (!string.IsNullOrEmpty(query.CategoryId))
                q = q.Where(t => t.CategoryId == query.CategoryId);

            if (query.From.HasValue)
                q = q.Where(t => t.Date >= query.From.Value);

            if (query.To.HasValue)
                q = q.Where(t => t.Date <= query.To.Value);

            return await q
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> ListByMonthAsync(int year, int month)
        {
            return await _db.Transactions
                .AsNoTracking()
                .ToListAsync()
                .ContinueWith(t => t.Result.FindAll(x => x.Date.Year == year && x.Date.Month == month));
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _db.Transactions.Update(transaction);
            await _db.SaveChangesAsync();
        }
    }
}
