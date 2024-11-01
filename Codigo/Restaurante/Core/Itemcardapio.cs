using System;
using System.Collections.Generic;

namespace Core;

public partial class Itemcardapio
{
    public uint Id { get; set; }

    public string? Nome { get; set; } = null!;

    public decimal? Preco { get; set; }

    public string? Detalhes { get; set; }

    public sbyte Ativo { get; set; }

    public string Disponivel { get; set; } = null!;

    public uint IdRestaurante { get; set; }

    public virtual Restaurante IdRestauranteNavigation { get; set; } = null!;

    public virtual ICollection<Pedidoitemcardapio> Pedidoitemcardapios { get; set; } = new List<Pedidoitemcardapio>();
}
