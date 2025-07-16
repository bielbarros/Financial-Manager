using FinancialManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialManager.Infrastructure.Data
{
    public class FinancialDbContext : DbContext
    {
        public FinancialDbContext(DbContextOptions<FinancialDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Transaction
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Category).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
            });

            // Configuração da entidade Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
            });

            // Seed data para categorias padrão
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Salário", Description = "Rendimentos do trabalho", Type = TransactionType.Income, IsActive = true },
                new Category { Id = 2, Name = "Freelance", Description = "Trabalhos extras", Type = TransactionType.Income, IsActive = true },
                new Category { Id = 3, Name = "Investimentos", Description = "Rendimentos de investimentos", Type = TransactionType.Income, IsActive = true },
                new Category { Id = 4, Name = "Alimentação", Description = "Gastos com comida", Type = TransactionType.Expense, IsActive = true },
                new Category { Id = 5, Name = "Transporte", Description = "Combustível, transporte público", Type = TransactionType.Expense, IsActive = true },
                new Category { Id = 6, Name = "Moradia", Description = "Aluguel, contas da casa", Type = TransactionType.Expense, IsActive = true },
                new Category { Id = 7, Name = "Lazer", Description = "Entretenimento e diversão", Type = TransactionType.Expense, IsActive = true },
                new Category { Id = 8, Name = "Saúde", Description = "Médico, farmácia", Type = TransactionType.Expense, IsActive = true },
                new Category { Id = 9, Name = "Educação", Description = "Cursos, livros", Type = TransactionType.Expense, IsActive = true },
                new Category { Id = 10, Name = "Outros", Description = "Outras despesas", Type = TransactionType.Expense, IsActive = true }
            );
        }
    }
} 