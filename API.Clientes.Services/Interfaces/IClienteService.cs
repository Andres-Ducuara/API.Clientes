using API.Clientes.DTOs;

namespace API.Clientes.Services.Interfaces;

public interface IClienteService
{
    Task<ClienteDto?> ObtenerPorIdentificacionAsync(string numeroIdentificacion, CancellationToken cancellationToken = default);
}
