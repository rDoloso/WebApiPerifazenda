using ApiPerifazenda.Data;
using ApiPerifazenda.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura a string de conexão do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona serviços ao contêiner de DI
builder.Services.AddControllers();

// Configuração do Swagger para API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona a configuração CORS para permitir todas as origens (ou personalize a origem)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()  // Permite qualquer origem
               .AllowAnyMethod()  // Permite qualquer método HTTP
               .AllowAnyHeader(); // Permite qualquer cabeçalho
    });
});

// Registra os serviços de aplicação (Login, Cliente, Venda)
builder.Services.AddScoped<ILoginInterface, LoginService>();
builder.Services.AddScoped<IClienteInterface, ClienteService>();
builder.Services.AddScoped<IVendaInterface, VendaService>();

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins"); // Aplica a política de CORS para todas as origens
app.UseAuthorization();

app.MapControllers();

app.Run();
