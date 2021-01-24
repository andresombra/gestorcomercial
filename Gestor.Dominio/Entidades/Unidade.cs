using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Dominio.Entidades
{
    public class Unidade : EntidadeBase
    {
        [Display(Name = "Unidades"), StringLength(50)]
        public string NomeUnidade { get; set; }

        [NotMapped]
        public List<Produto> Produtos { get; set; }
    }
}
