namespace ProjMVC5.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
            Enderecos = new List<Endereco>();
        }

        public Guid ClienteId { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        //Virtual indica que quem utilizar essa classe pode sobrescrever a property, e o entity framework faz isso,
        //alterando essa propriedade pra um proxy e ele busca apenas quando precisar, fazendo assim o lazy loading
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}