using Comercio.Domain;
using Comercio.Repository.MyContext;
using Comercio.Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Comercio.Repository.Repositories
{
    public class PedidoProdutoRepository : IPedidoProdutoRepository
    {
        private Context _context;

        public PedidoProdutoRepository(Context context)
        {
            _context = context;
        }

        public async Task<PedidoProduto> AddAsync(PedidoProduto pedido)
        {
            await _context.PedidosProdutos.AddAsync(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task DeleteAsync(PedidoProduto pedido)
        {
            _context.PedidosProdutos.Remove(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PedidoProduto>> GetAllAsync()
        {
            return await _context.PedidosProdutos.ToListAsync();
        }

        public async Task<PedidoProduto> GetByIdAsync(long id)
        {
            return await _context.PedidosProdutos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidoProduto>> GetByPedidoIdAsync(long id)
        {
            return await _context.PedidosProdutos.Where(x => x.PedidoId == id)
                                                 .Include(x => x.Pedido)
                                                 .Include(x => x.Produto)
                                                 .ToListAsync();
        }

        public async Task<List<PedidoProduto>> GetByProdutoIdAsync(long id)
        {
            return await _context.PedidosProdutos.Where(x => x.ProdutoId == id)
                                                 .Include(x => x.Pedido)
                                                 .Include(x => x.Produto)
                                                 .ToListAsync();
        }

        public async Task<PedidoProduto> UpdateAsync(PedidoProduto pedido)
        {
            _context.PedidosProdutos.Update(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }
    }
}