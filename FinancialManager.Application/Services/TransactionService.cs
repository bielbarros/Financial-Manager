using FinancialManager.Application.DTOs;
using FinancialManager.Domain.Entities;
using FinancialManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialManager.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionDto?> GetByIdAsync(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            return transaction != null ? MapToDto(transaction) : null;
        }

        public async Task<IEnumerable<TransactionDto>> GetAllAsync()
        {
            var transactions = await _transactionRepository.GetAllAsync();
            return transactions.Select(MapToDto);
        }

        public async Task<IEnumerable<TransactionDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var transactions = await _transactionRepository.GetByDateRangeAsync(startDate, endDate);
            return transactions.Select(MapToDto);
        }

        public async Task<IEnumerable<TransactionDto>> GetByTypeAsync(TransactionType type)
        {
            var transactions = await _transactionRepository.GetByTypeAsync(type);
            return transactions.Select(MapToDto);
        }

        public async Task<IEnumerable<TransactionDto>> GetByCategoryAsync(string category)
        {
            var transactions = await _transactionRepository.GetByCategoryAsync(category);
            return transactions.Select(MapToDto);
        }

        public async Task<decimal> GetTotalIncomeAsync()
        {
            return await _transactionRepository.GetTotalIncomeAsync();
        }

        public async Task<decimal> GetTotalExpenseAsync()
        {
            return await _transactionRepository.GetTotalExpenseAsync();
        }

        public async Task<decimal> GetBalanceAsync()
        {
            return await _transactionRepository.GetBalanceAsync();
        }

        public async Task<TransactionDto> CreateAsync(CreateTransactionDto dto)
        {
            var transaction = new Transaction
            {
                Description = dto.Description,
                Amount = dto.Amount,
                Type = dto.Type,
                Category = dto.Category,
                Date = dto.Date,
                CreatedAt = DateTime.Now
            };

            var createdTransaction = await _transactionRepository.AddAsync(transaction);
            return MapToDto(createdTransaction);
        }

        public async Task<TransactionDto> UpdateAsync(UpdateTransactionDto dto)
        {
            var existingTransaction = await _transactionRepository.GetByIdAsync(dto.Id);
            if (existingTransaction == null)
                throw new ArgumentException("Transação não encontrada");

            existingTransaction.Description = dto.Description;
            existingTransaction.Amount = dto.Amount;
            existingTransaction.Type = dto.Type;
            existingTransaction.Category = dto.Category;
            existingTransaction.Date = dto.Date;
            existingTransaction.UpdatedAt = DateTime.Now;

            var updatedTransaction = await _transactionRepository.UpdateAsync(existingTransaction);
            return MapToDto(updatedTransaction);
        }

        public async Task DeleteAsync(int id)
        {
            await _transactionRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _transactionRepository.ExistsAsync(id);
        }

        private static TransactionDto MapToDto(Transaction transaction)
        {
            return new TransactionDto
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Amount = transaction.Amount,
                Type = transaction.Type,
                Category = transaction.Category,
                Date = transaction.Date,
                CreatedAt = transaction.CreatedAt,
                UpdatedAt = transaction.UpdatedAt
            };
        }
    }
} 