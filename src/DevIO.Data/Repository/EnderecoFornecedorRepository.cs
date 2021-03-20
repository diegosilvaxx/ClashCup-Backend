using System;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class EnderecoFornecedorRepository : Repository<EnderecoFornecedor>, IEnderecoFornecedorRepository
    {
        public EnderecoFornecedorRepository(MeuDbContext context) : base(context) { }

        public async Task<EnderecoFornecedor> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.EnderecoFornecedores.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}