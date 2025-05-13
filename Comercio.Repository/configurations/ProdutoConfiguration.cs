using Comercio.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comercio.Repository.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos").HasKey(nameof(Produto.Id));

            builder.Property(nameof(Produto.Id)).HasColumnName("Id");
            builder.Property(nameof(Produto.Nome)).HasColumnName("Nome").IsRequired().HasMaxLength(100);
            builder.Property(nameof(Produto.Descricao)).HasColumnName("Descricao").HasMaxLength(300);
            builder.Property(nameof(Produto.Valor)).HasColumnName("Valor").IsRequired();
        }
    }
}