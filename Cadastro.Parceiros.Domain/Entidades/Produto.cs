using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Cadastro.Parceiros.Domain.Entidades
{
    [Table("Produto")]
    public class Produto
    {
        public Produto()
        {

        }
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int IdCategoria { get; set; }

        public Produto(string nome, int idCategoria)
        {
            Nome = nome;
            IdCategoria = idCategoria;
        }
    }
}