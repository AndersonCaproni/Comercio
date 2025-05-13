namespace Comercio.Domain
{
    public class PedidoProduto : Base
    {
        #region Atributo
        private int _qtdProdutos;
        private long _pedidoId;
        private long _produtoId;

        #endregion

        #region Propriedade
        public int QtdProdutos
        {
            get { return _qtdProdutos; }
            set { _qtdProdutos = value; }
        }

        public long PedidoId
        {
            get { return _pedidoId; }
            set { _pedidoId = value; }
        }
        public Pedido Pedido;

        public long ProdutoId
        {
            get { return _produtoId; }
            set { _produtoId = value; }
        }
        public Produto Produto;

        #endregion
    
    
    }
}