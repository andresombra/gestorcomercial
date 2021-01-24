using Gestor.Dominio.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Gestor.Dominio.Entidades
{
    public class PedidoItem
    {
        public PedidoItem()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public Guid PedidoId { get; set; }
        public int? UsuarioId { get; set; }
        [Display(Name = "Data")]
        public DateTime DataInclusao { get; set; }
        public int ProdutoId { get; set; }
        [NotMapped]
        public Produto Produto { get; set; }
        public decimal Valor { get; set; }
        public decimal Qtde { get; set; }
    }
}
