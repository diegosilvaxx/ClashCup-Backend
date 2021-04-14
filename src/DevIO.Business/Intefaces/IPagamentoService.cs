using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.DTO;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IPagamentoService : IDisposable
    {
        Task<bool> Adicionar(Pagamento fornecedor);
        Task<bool> Atualizar(Pagamento fornecedor);
        List<PagamentoFilterDto> Filter(List<Pagamento> cliente);

        Task<bool> Remover(Guid id);

    }
}