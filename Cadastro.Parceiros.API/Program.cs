using System.Data.Common;
using System.Reflection;
using Cadastro.Parceiros.API;
using Cadastro.Parceiros.Domain.Interfaces;
using Cadastro.Parceiros.Domain.Interfaces.Repositories;
using Cadastro.Parceiros.Domain.Interfaces.Services;
using Cadastro.Parceiros.Infra;
using Cadastro.Parceiros.Infra.Database.Migrations;
using Cadastro.Parceiros.Service;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);



var config = builder.Configuration;
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<DatabaseContext>();

builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddSqlServer2016()
            .WithGlobalConnectionString(config.GetConnectionString("SqlServer"))
            .ScanIn(Reflection.GetLoadedAssembly("Cadastro.Parceiros.Infra")).For.Migrations());


// builder.Services.AddScoped<DbConnection>(provider =>
//             {
//                 return new SqlConnection(config.GetConnectionString("SqlServer"));
//             });

builder.Services.AddControllers();

builder.Services.AddScoped<SessionDB>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

//Criar database
app.MigrateDatabase();


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
