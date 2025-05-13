using Comercio.Domain;

namespace Comercio.Repository.Repositories.Interface
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> GetAllAsync();
        Task<Pedido> GetByIdAsync(long id);
        Task<Pedido> AddAsync(Pedido pedido);
        Task<Pedido> UpdateAsync(Pedido pedido);
        Task DeleteAsync(Pedido pedido);
    }
}