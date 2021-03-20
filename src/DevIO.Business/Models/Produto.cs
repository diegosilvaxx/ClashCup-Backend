using System;

namespace DevIO.Business.Models
{
    public class Produto : Entity
    {
        public Produto()
        {
            DataCadastro = DateTime.Now.Date;
        }
        public Guid FornecedorId { get; set; }

        public string CodigoInterno { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Unidade { get; set; }

        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda{ get; set; }
        public int EstoqueMinimo{ get; set; }
        public int QuantidadeEstoque{ get; set; }
        public bool Ativo { get; set; }
        public string Observacao { get; set; }

        public DateTime DataCadastro { get; set; }
        public string Imagem { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}