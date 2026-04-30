# ApiPeliculas

API REST construida con **ASP.NET Core 8** para administrar categorías, películas y usuarios.  
El proyecto está en desarrollo, así que este README sirve como base para ir documentando el avance del curso.

## Tecnologías

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper
- Swagger / OpenAPI

## Funcionalidades actuales

- CRUD de categorías
- CRUD de películas
- Búsqueda de películas por nombre o descripción
- Relación película - categoría
- Registro e inicio de sesión de usuarios
- Base preparada para autenticación JWT

## Estructura general

- `Controllers/` → endpoints de la API
- `Repositorio/` → lógica de acceso a datos
- `Modelos/` → entidades y DTOs
- `Data/` → `DbContext`
- `Migrations/` → migraciones de Entity Framework
- `PeliculasMappers/` → perfiles de AutoMapper

## Requisitos

- .NET 8 SDK
- SQL Server
- Visual Studio 2026 o cualquier IDE compatible con .NET 8

## Configuración

1. Clonar el repositorio.
2. Configurar la cadena de conexión en `appsettings.json`.
3. Revisar la clave secreta si se utiliza autenticación JWT.
4. Aplicar migraciones de Entity Framework.
5. Ejecutar el proyecto.

Ejemplo de cadena de conexión:

```json
{
  "ConnectionStrings": {
    "ConexionSql": "Server=.;Database=ApiPeliculas;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

## Migraciones

Para crear o actualizar la base de datos:

```bash
dotnet ef database update
```

## Endpoints principales

### Categorías

- `GET /api/categorias`
- `GET /api/categorias/{categoriaId}`
- `POST /api/categorias`
- `PUT /api/categorias/{categoriaId}`
- `PATCH /api/categorias/{categoriaId}`
- `DELETE /api/categorias/{categoriaId}`

### Películas

- `GET /api/peliculas`
- `GET /api/peliculas/{peliculaId}`
- `GET /api/peliculas/Buscar?nombre=texto`
- `GET /api/peliculas/GetPeliculasEnCategorias/{categoriaId}`
- `POST /api/peliculas`
- `PATCH /api/peliculas/{peliculaId}`
- `DELETE /api/peliculas/{peliculaId}`

### Usuarios

- `POST /api/usuarios/registro`
- `POST /api/usuarios/login`

## Notas

- El proyecto todavía está en proceso de refactorización.
- Se están corrigiendo detalles de repositorios, controladores y consistencia de respuestas.
- Este documento irá creciendo a medida que avance el curso.

## Autor

Proyecto personal de práctica siguiendo un curso de ASP.NET Core.