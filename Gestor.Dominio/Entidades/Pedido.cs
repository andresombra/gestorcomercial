using System.Collections.Generic;
using Gestor.Dominio.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Dominio.Entidades
{
    public class Pedido 
    {
        public Pedido()
        {
            this.Id = Guid.NewGuid();
            this.Pedido_Item = new PedidoItem();
            this.Pedido_Item.PedidoId = this.Id;
        }

        [Key]
        public Guid Id { get; set; }
        public int? UsuarioId { get; set; }

        [Display(Name = "Data")]
        public DateTime DataInclusao { get; set; }

        public PedidoItem Pedido_Item { get; set; }

        [NotMapped]
        public virtual List<PedidoItem> PedidoItems { get; set; }

        [NotMapped]
        public virtual List<Produto> ListaProduto { get; set; }

        [Display(Name = "Tipo Pedido")]
        public ETipoPedido TipoPedido { get; set; }

        [Display(Name = "Situacao")]
        public EPedidoSituacao Situacao { get; set; }
        
        [Display(Name = "Cliente")]
        public int PessoaId { get; set; }
        public virtual Pessoa Cliente { get; set; }
        
        [Display(Name = "Vendedor")]
        public int VendedorId { get; set; }
        public virtual Pessoa Vendedor { get; set; }

        [StringLength(500, ErrorMessage = "No maximo 500 caracters")]
        public string Endereco { get; set; }
        [StringLength(500, ErrorMessage = "No maximo 500 caracters")]
        public string PontoReferencia { get; set; }
        [StringLength(20, ErrorMessage = "No maximo 20 caracters")]
        public string Telefone { get; set; }
        [StringLength(20, ErrorMessage = "No maximo 20 caracters")]
        public string Celular { get; set; }
        [StringLength(100, ErrorMessage = "No maximo 100 caracters")]
        public string Email { get; set; }
        [StringLength(500, ErrorMessage = "No maximo 500 caracters")]
        public string Observacao { get; set; }
    }
}
