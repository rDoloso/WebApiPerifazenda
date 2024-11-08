using ApiPerifazenda.Data;
using ApiPerifazenda.Service;
using Azure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura a string de conexão do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Scopo interfaces
builder.Services.AddScoped<ILoginInterface, LoginService>();
builder.Services.AddScoped<IClienteInterface, ClienteService>();
builder.Services.AddScoped<IVendaInterface, VendaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




void ConfigureServices(IServiceCollection services)
{
    // Adicionando CORS
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", builder =>
            builder.AllowAnyOrigin()  // Permite qualquer origem
                   .AllowAnyMethod()  // Permite qualquer método (GET, POST, etc.)
                   .AllowAnyHeader()); // Permite qualquer cabeçalho
    });

    services.AddControllers();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
