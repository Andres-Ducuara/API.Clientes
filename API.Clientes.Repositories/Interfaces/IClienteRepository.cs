using API.Clientes.Repositories.Entities;

namespace API.Clientes.Repositories.Interfaces;

public interface IClienteRepository
{
    Task<Cliente?> ObtenerPorIdentificacionAsync(string numeroIdentificacion, CancellationToken cancellationToken = default);
}
