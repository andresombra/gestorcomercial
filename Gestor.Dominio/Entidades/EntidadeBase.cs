using Gestor.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gestor.Dominio
{
    public class EntidadeBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UsuarioId { get; set; } = 0;
        [ScaffoldColumn(false)]
        public DateTime? DataInclusao { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? DataAtualizacao { get; set; }
    }
}
