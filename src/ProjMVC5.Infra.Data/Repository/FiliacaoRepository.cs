using ProjMVC5.Domain.Entities;
using ProjMVC5.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjMVC5.Infra.Data.Repository
{
    using Dapper;

    public class FiliacaoRepository : Repository<Cliente>, IFiliacaoRepository
    {
        public IEnumerable<Cliente> ObterAtivos()
        {
            return Buscar(c => c.Cpf != null && c.Ativo);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.Cpf == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        //Devido a um patern? event sourcing, nunca se deve excluir fisicamente um registro deste tipo, então se faz a exclusão lógica.
        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Ativo = false;
            Atualizar(cliente);
        }

        //método para consulta utilizando dapper
        public override IEnumerable<Cliente> ObterTodos()
        {
            var cn = this.Db.Database.Connection;
            var sql = "SELECT * FROM Clientes";

            return cn.Query<Cliente>(sql);
        }

        //método para consulta utilizando dapper, e fazendo joins
        public override Cliente ObterPorId(Guid id)
        {
            var cn = this.Db.Database.Connection;
            var sql = @"SELECT * FROM Clientes c
                        LEFT JOIN Enderecos e
                        ON c.ClienteId = e.ClienteId
                        WHERE c.ClienteId = sid";

            var cliente = cn.Query<Cliente, Endereco, Cliente>(sql, (c, e) =>
            {
                c.Enderecos.Add(e);
                return c;
            }, new { sid = id }, splitOn: "ClienteId, EnderecoId");

            return cliente.FirstOrDefault();
        }
    }
}