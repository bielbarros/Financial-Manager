using FinancialManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialManager.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> GetByTypeAsync(TransactionType type);
        Task<IEnumerable<Category>> GetActiveAsync();
        Task<Category> AddAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
    }
} 