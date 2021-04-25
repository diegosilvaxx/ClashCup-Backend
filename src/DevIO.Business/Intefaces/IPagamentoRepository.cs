using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        Task<List<Pagamento>> GetAllPassport();
        Task<int> JogadoresParticipante(Guid idTorneio);
    }
}