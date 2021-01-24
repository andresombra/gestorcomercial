using System.ComponentModel.DataAnnotations;

namespace Gestor.Dominio.Enums
{
    public enum ETipoPedido
    {
        [Display(Name = "1 - VENDA")]
        PEDIDO_VENDA = 1,

        [Display(Name = "2 - ORÇAMENTO")]
        PEDIDO_ORCAMENTO = 2,
        
        [Display(Name = "3 - DEVOLUÇÃO")]
        PEDIDO_DEVOLUCAO = 3,
        
        [Display(Name = "4 - TRANSFERENCIA")]
        PEDIDO_TRANSFERENCIA = 4,
        
        [Display(Name = "5 - VENDA ONLINE")]
        PEDIDO_VENDA_ONLINE = 5
    }
}
