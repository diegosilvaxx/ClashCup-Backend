using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class RankingRepository : Repository<Ranking>, IRankingRepository
    {
        public RankingRepository(MeuDbContext context) : base(context) { }

        public async Task<List<Ranking>> GetAllRanking()
        {
            return await Db.Rankings.AsNoTracking().ToListAsync();
        }
    }
}