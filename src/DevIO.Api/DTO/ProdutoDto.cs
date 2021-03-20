using System;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.DTO
{
    public class ProdutoDto
    {
        public ProdutoDto()
        {
            DataCadastro = DateTime.Now.Date;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]


        public Guid FornecedorId { get; set; }

        public string CodigoInterno { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Unidade { get; set; }
        public string ImagemUpload { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int EstoqueMinimo { get; set; }
        public int QuantidadeEstoque { get; set; }
        public bool Ativo { get; set; }
        public string Observacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Imagem { get; set; }
        [ScaffoldColumn(false)]
        public string NomeFornecedor { get; set; }
    }
}
