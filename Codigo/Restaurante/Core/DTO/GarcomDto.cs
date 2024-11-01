namespace Core.DTO
{
    public class GarcomDto
    {
        public uint Id { get; set; }
        public string? Nome { get; set; }
        public string Cpf { get; set; } = null!;
        public string? Telefone1 { get; set; }
        public string? Telefone2 { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public uint IdRestaurante { get; set; }
    }
}
