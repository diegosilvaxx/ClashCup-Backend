using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface ITorneioRepository : IRepository<Torneio>
    {
        Task<IEnumerable<Torneio>> GetTorneio();

    }
}