# API Clientes

Web API en .NET 7 con arquitectura por capas, Entity Framework Core, SQL Server y Swagger.

## Estructura

```text
API.Clientes.sln
+-- API.Clientes.Api
|   +-- Controllers/ClientesController.cs
|   +-- Program.cs
|   +-- appsettings.json
+-- API.Clientes.DTOs
|   +-- ClienteDto.cs
+-- API.Clientes.Repositories
|   +-- Entities/Cliente.cs
|   +-- Interfaces/IClienteRepository.cs
|   +-- ApplicationDbContext.cs
|   +-- ClienteRepository.cs
+-- API.Clientes.Services
|   +-- Interfaces/IClienteService.cs
|   +-- ClienteService.cs
+-- Database/01-DBClientes.sql
```

## Paquetes NuGet

- `API.Clientes.Api`: `Swashbuckle.AspNetCore` 6.5.0.
- `API.Clientes.Repositories`: `Microsoft.EntityFrameworkCore.SqlServer` 7.0.20.
- `API.Clientes.DTOs` y `API.Clientes.Services`: sin paquetes externos.

## Ejecución

1. Abrir `Database/01-DBClientes.sql` en SQL Server Management Studio y ejecutarlo contra la instancia de SQL Server 2019.
2. Revisar `API.Clientes.Api/appsettings.json`. Para una instancia local con autenticación de Windows funciona la cadena incluida. Para LocalDB se puede usar `Server=(localdb)\\MSSQLLocalDB;...`.
3. Ejecutar desde la raíz:

```powershell
dotnet restore API.Clientes.sln
dotnet run --project API.Clientes.Api
```

4. Abrir la URL que muestra la consola y agregar `/swagger`.
5. Probar `GET /api/clientes/1001001001`. Debe responder `200` con el usurio existente. Una identificación inexistente responde `404`.

El repositorio ejecuta `dbo.sp_ObtenerClientePorIdentificacion` mediante `FromSqlRaw` con un parámetro `SqlParameter`, evitando concatenar valores en SQL. El servicio aplica la validación básica y transforma la entidad a `ClienteDto`.
