using ProjMVC5.Domain.Entities;
using ProjMVC5.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMVC5.Infra.Data.Repository
{
    public class FiliacaoRepository : Repository<Cliente>, IFiliacaoRepository
    {
        public IEnumerable<Cliente> ObterAtivos()
        {
            return Buscar(c => c.Cpf != null && c.Ativo);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c=> c.Cpf == cpf).FirstOrDefault();
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
    }
}
