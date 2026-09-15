using API.Clientes.Repositories.Entities;
using API.Clientes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Clientes.Repositories;

public sealed class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext dbContext;

    public ClienteRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Cliente?> ObtenerPorIdentificacionAsync(
        string numeroIdentificacion,
        CancellationToken cancellationToken = default)
    {
        var parametro = new Microsoft.Data.SqlClient.SqlParameter("@NumeroIdentificacion", numeroIdentificacion);

        var clientes = await dbContext.Clientes
            .FromSqlRaw("EXEC dbo.sp_ObtenerClientePorIdentificacion @NumeroIdentificacion", parametro)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return clientes.SingleOrDefault();
    }
}
