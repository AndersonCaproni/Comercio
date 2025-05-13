using Comercio.Domain;
using Comercio.Repository.MyContext;
using Comercio.Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Comercio.Repository.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private Context _context;

        public PedidoRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido> GetByIdAsync(long id)
        {
            return await _context.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pedido> AddAsync(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> UpdateAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task DeleteAsync(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
        }

    }
}