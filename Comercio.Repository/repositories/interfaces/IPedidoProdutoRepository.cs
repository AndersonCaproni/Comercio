using Comercio.Domain;

namespace Comercio.Repository.Repositories.Interface
{
    public interface IPedidoProdutoRepository
    {
        Task<List<PedidoProduto>> GetAllAsync();
        Task<PedidoProduto> GetByIdAsync(long id);
        Task<List<PedidoProduto>> GetByPedidoIdAsync(long id);
        Task<List<PedidoProduto>> GetByProdutoIdAsync(long id);
        Task<PedidoProduto> AddAsync(PedidoProduto pedido);
        Task<PedidoProduto> UpdateAsync(PedidoProduto pedido);
        Task DeleteAsync(PedidoProduto pedido);
    }
}