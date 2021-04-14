using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class PagamentoRepository : Repository<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(MeuDbContext context) : base(context)
        {
            
        }

        public async Task<List<Pagamento>> GetAllPassport()
        {
            var pagamento = await Db.Pagamentos.Include(x => x.Torneio).Include(x => x.Jogador).ToListAsync();
            return pagamento;
        }

    }
}