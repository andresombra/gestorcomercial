using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gestor.Dominio.Entidades
{
    public class TipoPessoa : EntidadeBase
    {
        public string NomeTipoPessoa { get; set; }
        
        [NotMapped]
        public List<Pessoa> Pessoas { get; set; }
    }      
}
