using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.DTO;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoClienteRepository _enderecoRepository;
        private readonly IUser _user;

        public ClienteService(IClienteRepository clienteRepository,
                                 IEnderecoClienteRepository enderecoRepository,
                                 INotificador notificador,
                                 IUser user) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _user = user;
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)
                || !ExecutarValidacao(new EnderecoClienteValidation(), cliente.Endereco)) return false;


            if (_user.IsAuthenticated())
            {
                var userId = _user.GetUserId();
                var email = _user.GetUserEmail();
            }


            await _clienteRepository.Adicionar(cliente);
            return true;
        }


        public async Task<bool> Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return false;

            await _clienteRepository.Atualizar(cliente);
            return true;
        }

        public async Task AtualizarEndereco(EnderecoCliente endereco)
        {
            if (!ExecutarValidacao(new EnderecoClienteValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task<bool> Remover(Guid id)
        {
            var endereco = await _enderecoRepository.ObterEnderecoPorCliente(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
            }

            await _clienteRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }

        public List<ClienteFilterDto> Filter(List<Cliente> cliente)
        {
            var result = new List<ClienteFilterDto>();

            foreach (var item in cliente)
            {
                result.Add(new ClienteFilterDto
                {
                    Ativo = item.ClienteAtivo,
                    Codigo = item.Id.ToString(),
                    CpfCnpj = item.CPF + item.CNPJ,
                    Key = item.Id.ToString(),
                    Nome = item.Nome,
                    TipoCliente = item.TipoCliente
                }
                );
            }
            return result;
        }
    }
}