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
    public class TorneioRepository : Repository<Torneio>, ITorneioRepository
    {
        public TorneioRepository(MeuDbContext context) : base(context) { }



        public async Task<IEnumerable<Torneio>> GetTorneio()
        {
            return await Db.Torneios.AsNoTracking().ToListAsync();
        }
    }
}