using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.DTO;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class JogadorService : BaseService, IJogadorService
    {
        private readonly IJogadorRepository _jogadorRepository;
        private readonly IUser _user;

        public JogadorService(IJogadorRepository jogadorRepository,
                                 INotificador notificador,
                                 IUser user) : base(notificador)
        {
            _jogadorRepository = jogadorRepository;
            _user = user;
        }

        public async Task<bool> Adicionar(Jogador jogador)
        {
            if (_user.IsAuthenticated())
            {
                var userId = _user.GetUserId();
                var email = _user.GetUserEmail();
            }

            await _jogadorRepository.Adicionar(jogador);
            return true;
        }


        public async Task<bool> Atualizar(JogadorPutModelDto jogadorPut,Guid id)
        {
            var jogador = new Jogador
            {
                Celular = jogadorPut.Celular,
                Email = jogadorPut.Email,
                Nome = jogadorPut.Nome,
                IdClash = jogadorPut.IdClash,
                Id = id,
                UserId = jogadorPut.UserId,
                PagamentoId = jogadorPut.PagamentoId
            };

            await _jogadorRepository.Atualizar(jogador);
            return true;
        }


        public async Task<bool> Remover(Guid id)
        {
            await _jogadorRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _jogadorRepository?.Dispose();
        }

        public List<JogadorFilterDto> Filter(List<Jogador> jogador)
        {
            var result = new List<JogadorFilterDto>();

            foreach (var item in jogador)
            {
                result.Add(new JogadorFilterDto
                {
                    Celular = item.Celular,
                    Email = item.Email,
                    IdClash = item.IdClash
                }
                );
            }
            return result;
        }

        public async Task<Guid> GetById(string id)
        {
            var idGuid = Guid.Parse(id);
            var jogador = await _jogadorRepository.ObterIdByIdUser(idGuid);
            return jogador;
        }

        public async Task<string> GetIdClashById(string id)
        {
            var idGuid = Guid.Parse(id);
            var jogador = await _jogadorRepository.ObterIdClashByIdUser(idGuid);
            return jogador;
        }
    }
}