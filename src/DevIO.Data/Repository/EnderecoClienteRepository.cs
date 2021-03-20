using System;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class EnderecoClienteRepository : Repository<EnderecoCliente>, IEnderecoClienteRepository
    {
        public EnderecoClienteRepository(MeuDbContext context) : base(context) { }

        public async Task<EnderecoCliente> ObterEnderecoPorCliente(Guid clienteId)
        {
            return await Db.EnderecoCliente.AsNoTracking()
                .FirstOrDefaultAsync(f => f.ClienteId == clienteId);
        }
    }
}