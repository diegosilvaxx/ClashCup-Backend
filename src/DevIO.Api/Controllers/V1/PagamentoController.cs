using AutoMapper;
using DevIO.Api.Controllers.Common;
using DevIO.Api.DTO;
using DevIO.Api.Extensions;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PagamentoController : MainController
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPagamentoService _pagamentoService;
        private readonly IMapper _mapper;

        public PagamentoController(INotificador notificador,
                                    IMapper mapper,
                                    IPagamentoRepository pagamentoRepository,
                                    IPagamentoService pagamentoService,
                                    IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _pagamentoRepository = pagamentoRepository;
            _pagamentoService = pagamentoService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagamentoDto>>> ObterTodos()
        {
            var pagamentoes = await _pagamentoRepository.ObterTodos();
            var result = _pagamentoService.Filter(pagamentoes);

            return CustomResponse(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<PagamentoDto>>> ObterPorId(Guid id)
        {
            var pagamento = await _pagamentoRepository.Buscar(x => x.TorneioId == id);

            

            if (!pagamento.Any()) return CustomResponse(Ok()); 

            return CustomResponse(pagamento);
        }

        [HttpGet("Passport/{id:guid}")]
        public async Task<ActionResult<IEnumerable<PagamentoDto>>> GetPassport(Guid id)
        {
            var pagamento = await _pagamentoRepository.GetAllPassport();



            if (pagamento.Count == 0) {
                NotificarErro("Você não contém nenhum passport");
                return CustomResponse();
            }
            

            var pagamentos = pagamento.FindAll(x => x.JogadorId == id);

            var passport = new List<PassportDto>();

            foreach (var item in pagamentos)
            {
                passport.Add(new PassportDto
                {
                    Nome = item.Torneio.NomeTorneio,
                    Data = item.Torneio.DataTorneio.ToString("dd/MM/yyyy"),
                    HorarioAbertura = item.Torneio.HorarioAbertura,
                    HorarioInicio = item.Torneio.HorarioInicio,
                    Senha = item.Torneio.Senha,
                    ValorTorneio = item.Torneio.ValorTorneio
                });
            }

            return CustomResponse(passport);
        }

        [HttpPost]
        //[ClaimsAuthorize("Fornecedor", "Inserir")]
        public async Task<ActionResult<PagamentoDto>> Adicionar(PagamentoDto pagamentoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var pagamento = _mapper.Map<Pagamento>(pagamentoDto);
            await _pagamentoService.Adicionar(pagamento);

            return CustomResponse(pagamentoDto);
        }


        [HttpPut("{id:guid}")]
        //[ClaimsAuthorize("Fornecedor", "Alterar")]
        public async Task<ActionResult<PagamentoDto>> Alterar(Guid id, PagamentoDto pagamentoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var pagamento = _mapper.Map<Pagamento>(pagamentoDto);
            await _pagamentoService.Atualizar(pagamento);

            return CustomResponse(pagamentoDto);
        }

        [HttpDelete("{id:guid}")]
        //[ClaimsAuthorize("Fornecedor", "Remover")]
        public async Task<ActionResult<PagamentoDto>> Deletar(Guid id)
        {
            await _pagamentoService.Remover(id);

            return CustomResponse();

        }
    }
}