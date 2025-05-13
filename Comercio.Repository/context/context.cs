using System.Data;
using Comercio.Domain;
using Comercio.Repository.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Comercio.Repository.MyContext
{
    // Define o contexto do banco de dados, herda de DbContext para integrar com o Entity Framework.
    public class Context : DbContext
    {
        // String de conexão para o banco de dados, configurando o SQL Server.
        private string _stringConnection = "Server=(localdb)\\MSSQLLocalDB;Database=Comercio;Trusted_Connection=True";

        // Variável privada para manter a conexão aberta com o banco.
        private SqlConnection _connection;

        // Definição das entidades (tabelas) que serão gerenciadas pelo DbContext.
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoProduto> PedidosProdutos { get; set; }

        // Construtor padrão.
        public Context() { }

        // Construtor que recebe opções de configuração, utilizado principalmente para injeção de dependências.
        public Context(DbContextOptions<Context> options) : base(options) { }

        // Método para configurar a string de conexão. Ele é chamado automaticamente pelo Entity Framework.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verifica se a configuração já foi feita. Caso contrário, configura o banco de dados.
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_stringConnection); // Define a string de conexão com o SQL Server.
            }
        }

        // Método para configurar o mapeamento das entidades com as tabelas do banco de dados.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica as configurações personalizadas para o mapeamento das entidades.
            modelBuilder.ApplyConfiguration(new PedidoConfiguration()); // Mapeamento da entidade Pedido.
            modelBuilder.ApplyConfiguration(new PedidoProdutoConfiguration()); // Mapeamento da entidade PedidoProduto.
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration()); // Mapeamento da entidade Produto.
        }

        // Método para retornar uma conexão manual com o banco de dados.
        public IDbConnection Conexao()
        {
            // Cria uma nova conexão com o banco de dados.
            _connection = new SqlConnection(_stringConnection);
            //Abrindo a conexão 
            _connection.Open();
            // Retorna a conexão aberta ou criada.
            return _connection;
        }
    }
}
