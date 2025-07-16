using System.ComponentModel.DataAnnotations;

namespace FinancialManager.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string? Description { get; set; }
        
        public TransactionType Type { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
} 