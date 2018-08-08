using AutoMapper;
using ProjMVC5.Application.Interfaces;
using ProjMVC5.Domain.Entities;
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
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel);

            cliente.Enderecos.Add(endereco);

            _filiacaoRepository.Adicionar(cliente);

            return Mapper.Map<ClienteEnderecoViewModel>(cliente);
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_filiacaoRepository.ObterPorId(id));
        }
        
        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_filiacaoRepository.ObterTodos());
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            var clienteReturn = _filiacaoRepository.Atualizar(cliente);

            return Mapper.Map<ClienteViewModel>(clienteReturn);
        }
        
        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_filiacaoRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_filiacaoRepository.ObterPorEmail(email));
        }
        public void Remover(Guid id)
        {
            _filiacaoRepository.Remover(id);
        }

        public void Dispose()
        {
            _filiacaoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
        
    }
}
