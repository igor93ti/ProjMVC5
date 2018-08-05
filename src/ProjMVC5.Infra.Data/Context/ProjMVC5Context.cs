using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMVC5.Infra.Data.Context
{
    using ProjMVC5.Domain.Entities;
    using ProjMVC5.Infra.Data.EntityConfig;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ProjMVC5Context : DbContext
    {
        public ProjMVC5Context() 
            : base("DefaultConnection") //busca a conexão default definida no web.config da aplicação
        {

        }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Pega a propriedade que tem o "Nome Da Classe" + "Id" e configura como sendo chave primária
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());
            
            // Toda prop string, se não for definido previamente, vai ser por default varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            // Toda prop string, se não for definido previamente, vai ter o tamanho máximo de 100 
            modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}