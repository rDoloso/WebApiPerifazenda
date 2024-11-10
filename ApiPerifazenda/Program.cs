using ApiPerifazenda.Data;
using ApiPerifazenda.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura a string de conex�o do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona servi�os ao cont�iner de DI
builder.Services.AddControllers();

// Configura��o do Swagger para API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona a configura��o CORS para permitir todas as origens (ou personalize a origem)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()  // Permite qualquer origem
               .AllowAnyMethod()  // Permite qualquer m�todo HTTP
               .AllowAnyHeader(); // Permite qualquer cabe�alho
    });
});

// Registra os servi�os de aplica��o (Login, Cliente, Venda)
builder.Services.AddScoped<ILoginInterface, LoginService>();
builder.Services.AddScoped<IClienteInterface, ClienteService>();
builder.Services.AddScoped<IVendaInterface, VendaService>();

var app = builder.Build();

// Configura��o do pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins"); // Aplica a pol�tica de CORS para todas as origens
app.UseAuthorization();

app.MapControllers();

app.Run();
