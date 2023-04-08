using Cadastro.Parceiros.Domain.Interfaces;
using Cadastro.Parceiros.Domain.Interfaces.Repositories;
using Cadastro.Parceiros.Domain.Interfaces.Services;
using Cadastro.Parceiros.Infra;
using Cadastro.Parceiros.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var config = builder.Configuration;

//builder.Services.Configure<DatabaseConfiguration>(config.GetSection("ConnectionStrings:OracleIntranet"));
builder.Services.AddScoped<SessionDB>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// builder.Services.AddScoped((s) => new SqlConnection(config.GetConnectionString("SqlServer"));
// builder.Services.AddScoped<IDbTransaction>(s =>
// {
//     SqlConnection conn = s.GetRequiredService<SqlConnection>();
//     conn.Open();
//     return conn.BeginTransaction();
// });


builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
