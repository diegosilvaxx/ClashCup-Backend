using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.DTO;
using DevIO.Business.Models;
using DevIO.Business.Services;

namespace DevIO.Business.Intefaces
{
    public interface IClienteService : IDisposable
    {
        Task<bool> Adicionar(Cliente cliente);
        Task<bool> Atualizar(Cliente cliente);
        List<ClienteFilterDto> Filter(List<Cliente> cliente);
        Task<bool> Remover(Guid id);

        Task AtualizarEndereco(EnderecoCliente endereco);
    }
}