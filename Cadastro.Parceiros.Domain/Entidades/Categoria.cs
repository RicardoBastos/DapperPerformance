using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Cadastro.Parceiros.Domain.Entidades
{
    [Table("Categoria")]
    public class Categoria
    {
        [ExplicitKey]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public Guid IdProduto { get; set; }

    }
}