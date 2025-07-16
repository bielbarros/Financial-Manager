using FinancialManager.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialManager.Application.Services
{
    public interface ITransactionService
    {
        Task<TransactionDto?> GetByIdAsync(int id);
        Task<IEnumerable<TransactionDto>> GetAllAsync();
        Task<IEnumerable<TransactionDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<TransactionDto>> GetByTypeAsync(Domain.Entities.TransactionType type);
        Task<IEnumerable<TransactionDto>> GetByCategoryAsync(string category);
        Task<decimal> GetTotalIncomeAsync();
        Task<decimal> GetTotalExpenseAsync();
        Task<decimal> GetBalanceAsync();
        Task<TransactionDto> CreateAsync(CreateTransactionDto dto);
        Task<TransactionDto> UpdateAsync(UpdateTransactionDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
} 