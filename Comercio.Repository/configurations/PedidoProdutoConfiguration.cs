using Comercio.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comercio.Repository.Configurations
{
    // Classe de configuração para a entidade PedidoProduto usando Fluent API
    public class PedidoProdutoConfiguration : IEntityTypeConfiguration<PedidoProduto>
    {
        // Método que configura a entidade no modelo de dados
        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
            // Define o nome da tabela no banco de dados e a chave primária
            builder.ToTable("PedidosProdutos").HasKey(nameof(PedidoProduto.Id));

            // Configura o mapeamento da propriedade Id para a coluna "Id"
            builder.Property(nameof(PedidoProduto.Id)).HasColumnName("Id");

            // Configura o mapeamento da propriedade PedidoId para a coluna "PedidoId", tornando-a obrigatória
            builder.Property(nameof(PedidoProduto.PedidoId)).HasColumnName("PedidoId").IsRequired();

            // Configura o mapeamento da propriedade ProdutoId para a coluna "ProdutoId", tornando-a obrigatória
            builder.Property(nameof(PedidoProduto.ProdutoId)).HasColumnName("ProdutoId").IsRequired();

            // Configura o mapeamento da propriedade QtdProdutos para a coluna "QtdProdutos", tornando-a obrigatória
            builder.Property(nameof(PedidoProduto.QtdProdutos)).HasColumnName("QtdProdutos").IsRequired();

            // Configura o relacionamento de muitos para um entre PedidoProduto e Pedido
            builder.HasOne(pedido => pedido.Pedido)
                   .WithMany(pedidoProduto => pedidoProduto.PedidosProdutos)
                   .HasForeignKey(pedido => pedido.PedidoId);

            // Configura o relacionamento de muitos para um entre PedidoProduto e Produto
            builder.HasOne(x => x.Produto)
                   .WithMany(x => x.PedidosProdutos)
                   .HasForeignKey(x => x.ProdutoId);
        }
    }
}
