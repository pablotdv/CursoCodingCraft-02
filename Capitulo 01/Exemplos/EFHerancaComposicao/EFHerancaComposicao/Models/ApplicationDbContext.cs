using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFHerancaComposicao.Models
{
    public class ApplicationDbContext : DbContext
    {
        public System.Data.Entity.DbSet<EFHerancaComposicao.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<EFHerancaComposicao.Models.Pessoa> Pessoas { get; set; }
        public System.Data.Entity.DbSet<EFHerancaComposicao.Models.PessoaFisica> PessoaFisicas { get; set; }

        public System.Data.Entity.DbSet<EFHerancaComposicao.Models.Fornecedor> Fornecedors { get; set; }
    }
}