using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IJogadorRepository : IRepository<Jogador>
    {
        Task<Guid> ObterIdByIdUser(Guid id);
        Task<string> ObterIdClashByIdUser(Guid id);
    }
}