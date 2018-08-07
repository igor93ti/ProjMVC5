using ProjMVC5.Application.Interfaces;
using ProjMVC5.Domain.Interfaces.Repository;
using ProjMVC5.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMVC5.Application.Services
{
    public class FiliacaoAppService : IFiliacaoAppService
    {
        private readonly IFiliacaoRepository _filiacaoRepository;

        public FiliacaoAppService()
        {
            _filiacaoRepository = new FiliacaoRepository();
        }
        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            //faltando mapear com automapper
          //  return _filiacaoRepository.Adicionar(clienteEnderecoViewModel);
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
        }

        public void Dispose()
        {
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
