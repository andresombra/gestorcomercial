using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Dominio.Entidades
{
    public class Produto : EntidadeBase
    {
        [Display(Name = "Descrição do Produto/Serviço"), StringLength(200)]
        public string NomeProduto { get; set; }

        [Display(Name = "Unidade")]
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Fornecedor")]
        public int FornecedorId { get; set; }
        public Pessoa Fornecedor { get; set; }

        [Display(Name = "Código secundário"), StringLength(50)]
        public string CodigoSecundario { get; set; }

        [Display(Name = "Valor Venda")]
        [DataType(DataType.Currency), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###,##0.00}")]
        public decimal ValorVenda { get; set; }

        [Display(Name = "Valor Custo")]
        public decimal ValorCusto { get; set; }

        [Display(Name = "Disponível Estoque")]
        public decimal QtdeEstoque { get; set; }
    }
}
