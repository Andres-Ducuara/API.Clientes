namespace API.Clientes.Repositories.Entities;

public sealed class Cliente
{
    public int Id { get; set; }
    public string NumeroIdentificacion { get; set; } = string.Empty;
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public DateTime FechaCreacion { get; set; }
}
