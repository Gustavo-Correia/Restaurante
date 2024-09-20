using System;
using System.Collections.Generic;

namespace Core;

public partial class Atendimento
{
    public uint Id { get; set; }

    public DateTime DataHoraInicio { get; set; }

    public DateTime? DataHoraFim { get; set; }

    /// <summary>
    /// I - INICIADO
    /// C- CANCELADO
    /// F - FINALIZADO
    /// 
    /// </summary>
    public string Status { get; set; } = null!;

    public decimal TotalConta { get; set; }

    public decimal TotalServico { get; set; }

    public decimal TotalDesconto { get; set; }

    public decimal Total { get; set; }

    public int IdMesa { get; set; }

    public virtual Mesa IdMesaNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
