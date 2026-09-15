using API.Clientes.DTOs;
using API.Clientes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Clientes.Api.Controllers;

[ApiController]
[Route("api/clientes")]
[Produces("application/json")]
public sealed class ClientesController : ControllerBase
{
    private readonly IClienteService clienteService;
    private readonly ILogger<ClientesController> logger;

    public ClientesController(IClienteService clienteService, ILogger<ClientesController> logger)
    {
        this.clienteService = clienteService;
        this.logger = logger;
    }

    [HttpGet("{identificacion}")]
    [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ClienteDto>> ObtenerPorIdentificacion(
        string identificacion,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(identificacion))
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Solicitud inválida",
                Detail = "El número de identificación es obligatorio.",
                Status = StatusCodes.Status400BadRequest
            });
        }

        try
        {
            var cliente = await clienteService.ObtenerPorIdentificacionAsync(identificacion, cancellationToken);

            return cliente is null ? NotFound() : Ok(cliente);
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Solicitud inválida",
                Detail = exception.Message,
                Status = StatusCodes.Status400BadRequest
            });
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error consultando el cliente {Identificacion}", identificacion);
            return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
            {
                Title = "Error interno",
                Detail = "Ocurrió un error al consultar el cliente.",
                Status = StatusCodes.Status500InternalServerError
            });
        }
    }
}
