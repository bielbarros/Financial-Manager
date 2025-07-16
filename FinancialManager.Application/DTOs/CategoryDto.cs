using FinancialManager.Domain.Entities;

namespace FinancialManager.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TransactionType Type { get; set; }
        public bool IsActive { get; set; }
    }
    
    public class CreateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TransactionType Type { get; set; }
    }
    
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TransactionType Type { get; set; }
        public bool IsActive { get; set; }
    }
} 