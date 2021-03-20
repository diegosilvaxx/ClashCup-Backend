﻿using System;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Cliente> ObterClienteEndereco(Guid id)
        {
            var cliente = await Db.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            return await Db.Clientes.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> ObterClienteProdutosEndereco(Guid id)
        {
            return await Db.Clientes.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}