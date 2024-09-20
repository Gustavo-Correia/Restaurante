using System;
using System.Collections.Generic;

namespace Core;

public partial class Restaurante
{
    public uint Id { get; set; }

    public string Cnpj { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? Cep { get; set; }

    public string? Rua { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public string? Telefone1 { get; set; }

    public string? Telefone2 { get; set; }

    public virtual ICollection<Garcom> Garcoms { get; set; } = new List<Garcom>();

    public virtual ICollection<Itemcardapio> Itemcardapios { get; set; } = new List<Itemcardapio>();

    public virtual ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();
}
