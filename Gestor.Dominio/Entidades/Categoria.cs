using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Dominio.Entidades
{
    public class Categoria : EntidadeBase
    {
        [Required(ErrorMessage = "{0} e obrigatorio.")]
        [Display(Name ="Nome Categoria"), StringLength(100, MinimumLength = 3, ErrorMessage = "Qtds. de caracters, no minimo {2} e no maximo {1}.")]
        public string NomeCategoria { get; set; }

        [NotMapped]
        public List<Produto> Produtos { get; set; }
    }
}
