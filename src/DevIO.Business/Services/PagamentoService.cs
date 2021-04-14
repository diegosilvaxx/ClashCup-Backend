using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.DTO;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class PagamentoService : BaseService, IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUser _user;

        public PagamentoService(IPagamentoRepository pagamentoRepository, 
                                 INotificador notificador,
                                 IUser user) : base(notificador)
        {
            _pagamentoRepository = pagamentoRepository;
            _user = user;
        }

        public async Task<bool> Adicionar(Pagamento pagamento)
        {


            if (_user.IsAuthenticated())
            {
                var userId = _user.GetUserId();
                var email = _user.GetUserEmail();
            }


            await _pagamentoRepository.Adicionar(pagamento);
            return true;
        }

        public async Task<bool> Atualizar(Pagamento pagamento)
        {
            if (!ExecutarValidacao(new PagamentoValidation(), pagamento)) return false;

            await _pagamentoRepository.Atualizar(pagamento);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _pagamentoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _pagamentoRepository?.Dispose();
        }

        public List<PagamentoFilterDto> Filter(List<Pagamento> pagamento)
        {
            var result = new List<PagamentoFilterDto>();

            foreach (var item in pagamento)
            {
                result.Add(new PagamentoFilterDto
                {
                    Id = item.Id,
                    Email = item.Email,
                }
                );
            }
            return result;
        }
    }
}