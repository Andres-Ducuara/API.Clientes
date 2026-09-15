namespace API.Clientes.DTOs;

public sealed class ClienteDto
{
    public int Id { get; init; }
    public string NumeroIdentificacion { get; init; } = string.Empty;
    public string Nombres { get; init; } = string.Empty;
    public string Apellidos { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string? Telefono { get; init; }
    public DateTime FechaCreacion { get; init; }
}
