using ApiPeliculas.Data;
using ApiPeliculas.PeliculasMapper;
using ApiPeliculas.Repositorio;
using ApiPeliculas.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Agregamos los repositorios 
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IPeliculaRepositorio, PeliculaRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
//soportamos el CORS
builder.Services.AddCors(p => p.AddPolicy("PoliticaCors", build =>
    {
        build.WithOrigins("http://localhost:3223").AllowAnyMethod().AllowAnyHeader();
    }));

//Agregamos el AutoMapper
builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<PeliculasMapper>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PoliticaCors");
app.UseAuthorization();
app.MapControllers();
app.Run();app.Run();