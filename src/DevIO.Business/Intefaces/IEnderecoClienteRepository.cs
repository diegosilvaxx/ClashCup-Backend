using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IEnderecoClienteRepository : IRepository<EnderecoCliente>
    {
        Task<EnderecoCliente> ObterEnderecoPorCliente(Guid clienteId);
    }
}