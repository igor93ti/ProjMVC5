using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMVC5.Infra.Data.Context
{
    using ProjMVC5.Domain.Entities;

    public class ProjMVC5Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }
    }
}