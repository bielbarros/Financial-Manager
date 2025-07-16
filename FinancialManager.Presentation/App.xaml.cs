using FinancialManager.Application.Services;
using FinancialManager.Domain.Repositories;
using FinancialManager.Infrastructure.Data;
using FinancialManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace FinancialManager.Presentation
{
    public partial class App : System.Windows.Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            // Configurar Entity Framework
            services.AddDbContext<FinancialDbContext>(options =>
                options.UseSqlite("Data Source=FinancialManager.db"));

            // Registrar repositórios
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Registrar serviços
            services.AddScoped<ITransactionService, TransactionService>();

            // Registrar janela principal
            services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                base.OnStartup(e);

                // Criar e mostrar a janela principal
                var mainWindow = _serviceProvider.GetService<MainWindow>();
                if (mainWindow != null)
                {
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Erro ao criar a janela principal", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    Shutdown();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar a aplicação: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
            }
        }
    }
}

