using API.Clientes.DTOs;
using API.Clientes.Repositories.Interfaces;
using API.Clientes.Services.Interfaces;

namespace API.Clientes.Services;

public sealed class ClienteService : IClienteService
{
    private readonly IClienteRepository clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        this.clienteRepository = clienteRepository;
    }

    public async Task<ClienteDto?> ObtenerPorIdentificacionAsync(
        string numeroIdentificacion,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(numeroIdentificacion))
        {
            throw new ArgumentException("El número de identificación es obligatorio.", nameof(numeroIdentificacion));
        }

        var cliente = await clienteRepository.ObtenerPorIdentificacionAsync(
            numeroIdentificacion.Trim(),
            cancellationToken);

        if (cliente is null)
        {
            return null;
        }

        return new ClienteDto
        {
            Id = cliente.Id,
            NumeroIdentificacion = cliente.NumeroIdentificacion,
            Nombres = cliente.Nombres,
            Apellidos = cliente.Apellidos,
            Email = cliente.Email,
            Telefono = cliente.Telefono,
            FechaCreacion = cliente.FechaCreacion
        };
    }
}
