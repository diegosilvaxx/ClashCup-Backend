using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class TorneioService : BaseService, ITorneioService
    {
        private readonly ITorneioRepository _torneioRepository;

        public TorneioService(ITorneioRepository torneioRepository,
                              INotificador notificador) : base(notificador)
        {
            _torneioRepository = torneioRepository;
        }

        public async Task Adicionar(Torneio torneio)
        {
            if (!ExecutarValidacao(new TorneioValidation(), torneio)) return;

            await _torneioRepository.Adicionar(torneio);
        }

        public async Task Atualizar(Torneio torneio)
        {
            if (!ExecutarValidacao(new TorneioValidation(), torneio)) return;

            await _torneioRepository.Atualizar(torneio);
        }

        public async Task Remover(Guid id)
        {
            await _torneioRepository.Remover(id);
        }

        public void Dispose()
        {
            _torneioRepository?.Dispose();
        }

        public async Task<List<Torneio>> GetAll()
        {
            return await _torneioRepository?.ObterTodos();
        }
    }
}