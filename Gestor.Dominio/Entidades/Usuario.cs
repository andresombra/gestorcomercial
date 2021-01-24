using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        [Required(ErrorMessage = "{0} e obrigatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Qtds. de caracters, no minimo {2} e no maximo {1}.")]
        public string NomeUsuario { get; set; }
        
        [Required(ErrorMessage = "{0} e obrigatorio.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Qtds. de caracters, no minimo {2} e no maximo {1}.")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "{0} e obrigatorio.")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Qtds. de caracters, no minimo {2} e no maximo {1}.")]
        public string Senha { get; set; }
    }
}
