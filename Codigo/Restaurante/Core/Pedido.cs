using System;
using System.Collections.Generic;

namespace Core;

public partial class Pedido
{
    public uint Id { get; set; }

    public DateTime DataHoraSolicitacao { get; set; }

    public DateTime DaaHoraAtendimento { get; set; }

    public uint IdAtendimento { get; set; }

    public uint IdGarcom { get; set; }

    /// <summary>
    /// S - SOLICITADO
    /// C - CANCELADO
    /// A - ATENDIDO
    /// </summary>
    public string Status { get; set; } = null!;

    public string? Pedidocol { get; set; }

    public virtual Atendimento IdAtendimentoNavigation { get; set; } = null!;

    public virtual Garcom IdGarcomNavigation { get; set; } = null!;

    public virtual ICollection<Pedidoitemcardapio> Pedidoitemcardapios { get; set; } = new List<Pedidoitemcardapio>();
}
