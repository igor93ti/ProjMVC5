using ProjMVC5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMVC5.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        //mapeamento opcional das propriedades da entidade para a criação das tabelas no banco
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome).IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar");

            Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation( //atribui um indice ao CPF
                    new IndexAttribute("IX_CPF") { IsUnique = true }));

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            ToTable("Clientes");
        }
    }
}
