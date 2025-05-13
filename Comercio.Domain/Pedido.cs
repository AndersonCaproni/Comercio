namespace Comercio.Domain
{
    // Classe Pedido representa uma entidade de pedido no domínio do comércio.
    // Herda da classe Base.
    public class Pedido : Base
    {
        #region Atributo

        // Armazena a data em que o pedido foi realizado.
        private DateTime _dataPedido;

        // Lista que contém os produtos associados ao pedido.
        private List<PedidoProduto> _pedidosProdutos;

        #endregion

        #region Propriedade

        // Propriedade pública para acessar/modificar a data do pedido.
        public DateTime DataPedido
        {
            get { return _dataPedido; }
            set { _dataPedido = value; }
        }

        // Propriedade pública para acessar/modificar a lista de produtos do pedido.
        public List<PedidoProduto> PedidosProdutos
        {
            get { return _pedidosProdutos; }
            set { _pedidosProdutos = value; }
        }

        #endregion

        #region Construtor

        // Construtor da classe. Inicializa a lista de produtos para evitar NullReferenceException.
        public Pedido()
        {
            PedidosProdutos = new List<PedidoProduto>();
        }

        #endregion
    }
}
