using System;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class JogadorRepository : Repository<Jogador>, IJogadorRepository
    {
        public JogadorRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Guid> ObterIdByIdUser(Guid id)
        {
            var jogador = await Db.Jogadores.FirstOrDefaultAsync(x => x.UserId == id.ToString());
            return jogador.Id;
        }

        public async Task<string> ObterIdClashByIdUser(Guid id)
        {
            var jogador = await Db.Jogadores.FirstOrDefaultAsync(x => x.UserId == id.ToString());
            return jogador.IdClash;
        }
    }
}