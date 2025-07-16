using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services;
using FinancialManager.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FinancialManager.Presentation
{
    public partial class MainWindow : Window
    {
        private List<TransactionDto> _transacoes = new();
        private List<TransactionDto> _transacoesFiltradas = new();

        public MainWindow()
        {
            InitializeComponent();
            PreencherCategorias();
            TransactionsDataGrid.ItemsSource = _transacoesFiltradas;
            AtualizarDemonstrativo();
        }

        private void PreencherCategorias()
        {
            var categoriasReceita = new[] { "Salário", "Freelance", "Investimentos", "Outros" };
            var categoriasDespesa = new[] { "Alimentação", "Transporte", "Moradia", "Lazer", "Saúde", "Educação", "Outros" };
            CategoryComboBox.Items.Clear();
            var tipoSelecionado = ObterTipoSelecionado();
            var categorias = tipoSelecionado == "Income" ? categoriasReceita : categoriasDespesa;
            foreach (var cat in categorias)
                CategoryComboBox.Items.Add(cat);
            if (CategoryComboBox.Items.Count > 0)
                CategoryComboBox.SelectedIndex = 0;
        }

        private string ObterTipoSelecionado()
        {
            if (TransactionTypeComboBox.SelectedItem is ComboBoxItem item)
                return item.Tag?.ToString() ?? "Income";
            return "Income";
        }

        private void AplicarFiltros()
        {
            var transacoesFiltradas = _transacoes.AsEnumerable();

            // Filtro por período
            if (PeriodFilterComboBox.SelectedItem is ComboBoxItem periodItem)
            {
                var hoje = DateTime.Today;
                switch (periodItem.Tag?.ToString())
                {
                    case "ThisMonth":
                        transacoesFiltradas = transacoesFiltradas.Where(t => t.Date.Month == hoje.Month && t.Date.Year == hoje.Year);
                        break;
                    case "LastMonth":
                        var mesAnterior = hoje.AddMonths(-1);
                        transacoesFiltradas = transacoesFiltradas.Where(t => t.Date.Month == mesAnterior.Month && t.Date.Year == mesAnterior.Year);
                        break;
                    case "ThisYear":
                        transacoesFiltradas = transacoesFiltradas.Where(t => t.Date.Year == hoje.Year);
                        break;
                    case "All":
                    default:
                        // Não aplicar filtro de período
                        break;
                }
            }

            // Filtro por tipo
            if (TypeFilterComboBox.SelectedItem is ComboBoxItem typeItem)
            {
                switch (typeItem.Tag?.ToString())
                {
                    case "Income":
                        transacoesFiltradas = transacoesFiltradas.Where(t => t.Type == TransactionType.Income);
                        break;
                    case "Expense":
                        transacoesFiltradas = transacoesFiltradas.Where(t => t.Type == TransactionType.Expense);
                        break;
                    case "All":
                    default:
                        // Não aplicar filtro de tipo
                        break;
                }
            }

            _transacoesFiltradas = transacoesFiltradas.ToList();
            TransactionsDataGrid.ItemsSource = null;
            TransactionsDataGrid.ItemsSource = _transacoesFiltradas;
            AtualizarDemonstrativo();
        }

        private void AtualizarDemonstrativo()
        {
            // Usar transações filtradas para o demonstrativo
            var receitas = _transacoesFiltradas.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount);
            var despesas = _transacoesFiltradas.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount);
            var saldo = receitas - despesas;

            TotalIncomeText.Text = receitas.ToString("C");
            TotalExpenseText.Text = despesas.ToString("C");
            BalanceText.Text = saldo.ToString("C");
        }

        private void TransactionTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PreencherCategorias();
        }

        private void AddTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            // Validação simples
            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text) || string.IsNullOrWhiteSpace(AmountTextBox.Text) || CategoryComboBox.SelectedItem == null || !decimal.TryParse(AmountTextBox.Text, out decimal valor))
            {
                MessageBox.Show("Preencha todos os campos corretamente!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var tipo = ObterTipoSelecionado() == "Income" ? TransactionType.Income : TransactionType.Expense;
            var transacao = new TransactionDto
            {
                Id = _transacoes.Count + 1,
                Description = DescriptionTextBox.Text.Trim(),
                Amount = valor,
                Type = tipo,
                Category = CategoryComboBox.SelectedItem?.ToString() ?? "",
                Date = DatePicker.SelectedDate ?? DateTime.Today,
                CreatedAt = DateTime.Now
            };
            _transacoes.Add(transacao);
            AplicarFiltros(); // Aplicar filtros após adicionar transação
            MessageBox.Show("Transação registrada! (em memória)", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            // Limpar formulário
            DescriptionTextBox.Text = string.Empty;
            AmountTextBox.Text = string.Empty;
            CategoryComboBox.SelectedIndex = 0;
            DatePicker.SelectedDate = DateTime.Today;
        }

        private void PeriodFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AplicarFiltros();
        }

        private void TypeFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AplicarFiltros();
        }

        private void UpdateTransactionButton_Click(object sender, RoutedEventArgs e) { }
        private void CancelButton_Click(object sender, RoutedEventArgs e) { }
        private void TransactionsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
    }
}