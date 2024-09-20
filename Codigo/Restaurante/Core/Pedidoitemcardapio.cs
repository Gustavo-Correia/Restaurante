using System;
using System.Collections.Generic;

namespace Core;

public partial class Pedidoitemcardapio
{
    public uint IdItemCardapio { get; set; }

    public uint IdPedido { get; set; }

    public decimal Quantidade { get; set; }

    public virtual Itemcardapio IdItemCardapioNavigation { get; set; } = null!;

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
