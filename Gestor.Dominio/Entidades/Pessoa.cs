using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Dominio.Entidades
{
    public class Pessoa : EntidadeBase
    {
        [Required(ErrorMessage = "{0} e obrigatorio.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Qtds. de caracters, no minimo {2} e no maximo {1}.")]
        public string Nome { get; set; }
        [StringLength(150)]
        public string Endereco { get; set; }
        [StringLength(150)]
        public string Bairro { get; set; }
        [StringLength(10)]
        public string Cep { get; set; }
        public int LocalizacaoId { get; set; } = 0;
        [StringLength(100)]
        public string Cidade { get; set; }
        [StringLength(100)]
        public string Estado { get; set; }
        [StringLength(2)]
        public string UF { get; set; }
        [StringLength(150)]
        public string Complemento { get; set; }
        [Display(Name = "E-mail"), StringLength(100)]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Formato do E-mail Inválido")]
        public string Email { get; set; }
        [StringLength(15)]
        public string Telefone { get; set; }
        [StringLength(15)]
        public string Celular { get; set; }
        [Display(Name = "CPF/CNPJ"), StringLength(20)]
        public string CpfCnpj { get; set; }
        public int Situacao { get; set; } = 0;
        [Display(Name = "Tipo Pessoa")]
        public int TipoPessoaId { get; set; }
        public TipoPessoa TipoPessoa { get; set; }

        [NotMapped]
        public List<Produto> Produtos { get; set; }

        //[Display(Name = "Salário")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###,##0.00}")]
        //public double? Salario { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date, ErrorMessage = "Uma data válida deve ser informada!")]
        //public DateTime? Data { get; set; }
    }
}
