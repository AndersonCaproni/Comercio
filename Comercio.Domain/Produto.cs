namespace Comercio.Domain
{
    public class Produto : Base
    {
        #region Atributo
        private string _nome;
        private string _valor;
        private string _descricao;
        private List<PedidoProduto> _pedidosProdutos;

        #endregion

        #region Propriedade
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public List<PedidoProduto> PedidosProdutos
        {
            get { return _pedidosProdutos; }
            set { _pedidosProdutos = value; }
        }

        #endregion

        #region Construtor
        public Produto()
        {
            PedidosProdutos = new List<PedidoProduto>();
        }

        #endregion

    }
}

