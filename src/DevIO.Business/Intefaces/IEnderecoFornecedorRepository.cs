using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IEnderecoFornecedorRepository : IRepository<EnderecoFornecedor>
    {
        Task<EnderecoFornecedor> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}