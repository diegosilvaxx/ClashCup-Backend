using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.DTO;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IFornecedorService : IDisposable
    {
        Task<bool> Adicionar(Fornecedor fornecedor);
        Task<bool> Atualizar(Fornecedor fornecedor);
        List<FornecedorFilterDto> Filter(List<Fornecedor> cliente);

        Task<bool> Remover(Guid id);

        Task AtualizarEndereco(EnderecoFornecedor endereco);
    }
}