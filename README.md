# Sistema de Controle Financeiro

Um sistema robusto de controle financeiro desenvolvido em C# com WPF, seguindo arquitetura em camadas (Clean Architecture).

##  Arquitetura do Projeto

### Estrutura de Pastas

```
FinancialManager/
├── FinancialManager.Domain/           # Camada de Domínio
│   ├── Entities/                     # Entidades do domínio
│   │   ├── Transaction.cs
│   │   └── Category.cs
│   └── Repositories/                  # Interfaces dos repositórios
│       ├── ITransactionRepository.cs
│       └── ICategoryRepository.cs
│
├── FinancialManager.Application/       # Camada de Aplicação
│   ├── DTOs/                         # Data Transfer Objects
│   │   ├── TransactionDto.cs
│   │   └── CategoryDto.cs
│   └── Services/                      # Serviços de aplicação
│       ├── ITransactionService.cs
│       └── TransactionService.cs
│
├── FinancialManager.Infrastructure/   # Camada de Infraestrutura
│   ├── Data/                         # Contexto do Entity Framework
│   │   ├── FinancialDbContext.cs
│   │   └── DesignTimeDbContextFactory.cs
│   └── Repositories/                  # Implementações dos repositórios
│       ├── TransactionRepository.cs
│       └── CategoryRepository.cs
│
└── FinancialManager.Presentation/     # Camada de Apresentação (WPF)
    ├── MainWindow.xaml               # Interface principal
    ├── MainWindow.xaml.cs            # Código-behind
    ├── App.xaml                      # Configuração da aplicação
    └── App.xaml.cs                   # Injeção de dependência
```

##  Funcionalidades

###  Implementadas e Funcionando
- ✅ **Cadastrar transações** (Receitas e Despesas)
- ✅ **Listar transações** em tempo real na DataGrid
- ✅ **Exibir saldo** (Receitas - Despesas) atualizado automaticamente
- ✅ **Categorias dinâmicas** baseadas no tipo de transação
- ✅ **Validação de formulário** completa
- ✅ **Interface moderna** com WPF
- ✅ **Arquitetura em camadas** (Clean Architecture)
- ✅ **Banco de dados SQLite** configurado e funcionando
- ✅ **Filtros por período** (Este mês, Mês anterior, Este ano, Todos)
- ✅ **Filtros por tipo** (Receitas, Despesas, Todos)
- ✅ **Filtros combinados** (período + tipo funcionam juntos)
- ✅ **Demonstrativo financeiro** baseado nos filtros aplicados

###  Em Desenvolvimento
-  Editar transações existentes
-  Persistência real no banco de dados
-  Exclusão de transações

###  Categorias Padrão
**Receitas:**
- Salário
- Freelance
- Investimentos
- Outros

**Despesas:**
- Alimentação
- Transporte
- Moradia
- Lazer
- Saúde
- Educação
- Outros

##  Tecnologias Utilizadas

- **.NET 9.0** - Framework principal
- **C#** - Linguagem de programação
- **WPF** - Interface gráfica
- **Entity Framework Core** - ORM para acesso a dados
- **SQLite** - Banco de dados (arquivo local)
- **Microsoft.Extensions.DependencyInjection** - Injeção de dependência

##  Pré-requisitos

- Visual Studio 2022 ou VS Code
- .NET 9.0 SDK
- SQLite (incluído no Entity Framework)

##  Como Executar

1. **Clone o repositório:**
   ```bash
   git clone [url-do-repositorio]
   cd FinancialManager
   ```

2. **Restaure as dependências:**
   ```bash
   dotnet restore
   ```

3. **Execute as migrações do banco de dados:**
   ```bash
   cd FinancialManager.Infrastructure
   dotnet ef database update --startup-project ../FinancialManager.Presentation
   ```

4. **Execute a aplicação:**
   ```bash
   cd ../FinancialManager.Presentation
   dotnet run
   ```

##  Arquitetura em Camadas

### Domain Layer
- **Entidades**: Representam os objetos de negócio
- **Repositórios**: Interfaces para acesso a dados
- **Regras de negócio**: Validações e lógica central

### Application Layer
- **DTOs**: Objetos de transferência de dados
- **Serviços**: Orquestração de operações de negócio
- **Mapeamentos**: Conversão entre entidades e DTOs

### Infrastructure Layer
- **DbContext**: Configuração do Entity Framework
- **Repositórios**: Implementação concreta dos repositórios
- **Configurações**: Conexões de banco de dados

### Presentation Layer
- **Views**: Interfaces WPF
- **ViewModels**: Lógica de apresentação
- **Injeção de Dependência**: Configuração de serviços

## 🔧 Configuração do Banco de Dados

O projeto está configurado para usar **SQLite** (arquivo local). A string de conexão está definida em `App.xaml.cs`:

```csharp
"Data Source=FinancialManager.db"
```

O arquivo do banco (`FinancialManager.db`) será criado automaticamente na primeira execução.

##  Status Atual

### ✅ **Funcionando Perfeitamente:**
- Interface WPF moderna e responsiva
- Cadastro de transações com validação
- Listagem em tempo real
- Demonstrativo financeiro atualizado automaticamente
- Categorias dinâmicas
- **Filtros funcionais por período e tipo**
- **Filtros combinados** (período + tipo)
- **Demonstrativo baseado nos filtros**
- Arquitetura completa implementada

###  **Próximos Passos:**
1. **Ativar persistência real** no banco SQLite
2. **Adicionar edição** de transações
3. **Implementar exclusão** de transações
4. **Adicionar gráficos** com LiveCharts

##  Funcionalidades de Filtro

### Filtros por Período:
- **Todos**: Mostra todas as transações
- **Este mês**: Apenas transações do mês atual
- **Mês anterior**: Transações do mês passado
- **Este ano**: Transações do ano atual

### Filtros por Tipo:
- **Todos**: Receitas e despesas
- **Receitas**: Apenas transações de receita
- **Despesas**: Apenas transações de despesa

### Funcionalidades dos Filtros:
- ✅ **Filtros combinados** (período + tipo funcionam juntos)
- ✅ **Atualização automática** da lista ao filtrar
- ✅ **Demonstrativo financeiro** baseado nos filtros aplicados
- ✅ **Atualização automática** ao adicionar nova transação

##  Próximas Funcionalidades

- [ ] Persistência real no banco de dados
- [ ] Edição de transações existentes
- [ ] Exclusão de transações
- [ ] Gráficos com LiveCharts
- [ ] Relatórios em PDF
- [ ] Exportação para Excel
- [ ] Backup automático
- [ ] Múltiplas contas
- [ ] Metas financeiras
- [ ] Lembretes de pagamentos

##  Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request


##  Autor

*Gabriel Barros*

Desenvolvido para aprendizado de arquitetura .NET com C# e WPF.

---

**Nota**: Este projeto foi criado para demonstrar as melhores práticas de arquitetura em .NET, especialmente para desenvolvedores migrando de Java/Spring para .NET/C#. 

**Status**: ✅ **FUNCIONANDO** - Sistema básico completo e operacional com filtros funcionais! # Financial-Manager
