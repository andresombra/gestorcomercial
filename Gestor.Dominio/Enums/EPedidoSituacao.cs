using System.ComponentModel.DataAnnotations;

namespace Gestor.Dominio.Enums
{
    public enum EPedidoSituacao
    {
        [Display(Name = "1 - EM ABERTO")]
        PEDIDO_EM_ABERTO = 1,

        [Display(Name = "2 - CONCLUIDO")]
        PEDIDO_CONCLUIDO = 2,

        [Display(Name = "3 - CANCELADO")]
        PEDIDO_CANCELADO = 3,

        [Display(Name = "4 - DEVOLVIDO")]
        PEDIDO_DEVOLVIDO = 4
    }
}
