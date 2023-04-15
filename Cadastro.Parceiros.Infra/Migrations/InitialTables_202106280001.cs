using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator;

namespace Cadastro.Parceiros.Infra.Database.Migrations
{
    [Migration(0001)]
    public class InitialTables : Migration
    {
        public override void Up()
        {
            Create.Table("Produto")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Nome").AsAnsiString(50).NotNullable()
            .WithColumn("IdCategoria").AsInt32().NotNullable();

            Create.Table("Categoria")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Nome").AsAnsiString(50).NotNullable();

            Create.ForeignKey("FK_Produto_Categoria")
               .FromTable("Produto").ForeignColumn("IdCategoria")
               .ToTable("Categoria").PrimaryColumn("Id");

            InserirCategoria("Limpeza");
            InserirProduto("Sabão");
        }

        private void InserirCategoria(string nomeCategoria)
        {
            Insert.IntoTable("Categoria").Row(new
            {
                Nome = nomeCategoria
            });
        }

        private void InserirProduto(string nomeProduto)
        {
            Insert.IntoTable("Produto").Row(new
            {
                Nome = nomeProduto,
                IdCategoria = 1
            });
        }

        public override void Down()
        {
            Delete.Table("Produto");
            Delete.Table("Categoria");
        }
    }
}