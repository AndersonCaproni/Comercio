using Comercio.Domain;

namespace Comercio.Repository.Repositories.Interface
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(long id);
        Task<Produto> AddAsync(Produto Produto);
        Task<Produto> UpdateAsync(Produto Produto);
        Task DeleteAsync(Produto Produto);
    }
}