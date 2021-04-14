using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface ITorneioService : IDisposable
    {
        Task Adicionar(Torneio produto);
        Task Atualizar(Torneio produto);
        Task Remover(Guid id);

        Task<List<Torneio>> GetAll();

    }
}