using Comercio.Domain;
using Comercio.Repository.MyContext;
using Comercio.Repository.Repositories.Interface;
using Dapper;

namespace Comercio.Repository.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private Context _context;

        public ProdutoRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAllExemploAsync()
        {
            var sql = @$"select * from Produtos";

            using (var conexao = _context.Conexao())
            {
                var produtos = await conexao.QueryAsync<Produto>(sql);

                return produtos;
            }
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            var sql = @$"SELECT * FROM Produtos;";

            using (var conexao = _context.Conexao())
            {
                conexao.Open();

                var produtos = await conexao.QueryAsync<Produto>(sql);

                return produtos.ToList();
            }
        }

        public async Task DeleteAsync(Produto produto)
        {
            var sql = @$"DELETE FROM Produtos WHERE Id = @produtoId;";

            using (var conexao = _context.Conexao())
            {
                await conexao.ExecuteAsync(sql, new
                {
                    produtoId = produto.Id
                });
            }
        }

        public async Task<Produto> AddAsync(Produto produto)
        {
            var sql = @"
                        INSERT INTO Produtos (Nome, Valor, Descricao) 
                        VALUES (@nome, @valor, @descricao);
                        SELECT CAST(SCOPE_IDENTITY() as int);
                        ";

            using (var conexao = _context.Conexao())
            {
                var id = await conexao.ExecuteScalarAsync<long>(sql, new
                {
                    nome = produto.Nome,
                    descricao = produto.Descricao,
                    valor = produto.Valor
                });

                produto.Id = id;
                return produto;
            }
        }

        public async Task<Produto> UpdateAsync(Produto produto)
        {
            var sql = @$"Update Produtos set Nome = @nome, Valor = @valor, Descricao = @descricao WHERE Id = @id;";

            using (var conexao = _context.Conexao())
            {
                await conexao.ExecuteAsync(sql, new
                {
                    id = produto.Id,
                    nome = produto.Nome,
                    descricao = produto.Descricao,
                    valor = produto.Valor
                });

                return produto;
            }
        }

        public async Task<Produto> GetByIdAsync(long id)
        {
            var sql = @$"SELECT * FROM Produtos WHERE Id = @produtoId;";

            using (var conexao = _context.Conexao())
            {
                return await conexao.QueryFirstOrDefaultAsync<Produto>(sql, new {produtoId = id});
            }
        }
    }
}