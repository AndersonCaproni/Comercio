using Microsoft.EntityFrameworkCore;
using Comercio.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comercio.Repository.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos").HasKey(nameof(Pedido.Id));

            builder.Property(nameof(Pedido.Id)).HasColumnName("Id");
            builder.Property(nameof(Pedido.DataPedido)).HasColumnName("DataPedido").IsRequired();
        }
    }
}