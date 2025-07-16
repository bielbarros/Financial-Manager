using System;
using System.ComponentModel.DataAnnotations;

namespace FinancialManager.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public TransactionType Type { get; set; }
        
        [Required]
        public string Category { get; set; } = string.Empty;
        
        [Required]
        public DateTime Date { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedAt { get; set; }
    }
    
    public enum TransactionType
    {
        Income = 1,
        Expense = 2
    }
} 