using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IRankingRepository : IRepository<Ranking>
    {
        Task<List<Ranking>> GetAllRanking();
    }
}