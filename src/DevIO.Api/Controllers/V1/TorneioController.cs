using AutoMapper;
using DevIO.Api.Controllers.Common;
using DevIO.Api.DTO;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevIO.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class TorneioController : MainController
    {
        private readonly ITorneioRepository _torneioRepository;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly ITorneioService _torneioService;
        private readonly IMapper _mapper;


        public TorneioController(INotificador notificador,
                                 IMapper mapper,
                                 ITorneioRepository torneioRepository,
                                 ITorneioService torneioService,
                                 IUser user, IPagamentoRepository pagamentoRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _torneioRepository = torneioRepository;
            _torneioService = torneioService;
            _pagamentoRepository = pagamentoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TorneioDto>>> ObterTodos()
        {
            var result = await _torneioRepository.ObterTodos();
            List<TorneioDto> torneio = new List<TorneioDto>();

            foreach (var item in result)
            {
                torneio.Add(new TorneioDto
                {
                    DataTorneio = item.DataTorneio.ToString(),
                    Descricao = item.Descricao,
                    Excluido = item.Excluido,
                    HorarioAbertura = item.HorarioAbertura,
                    HorarioInicio = item.HorarioInicio,
                    NomeTorneio = item.NomeTorneio,
                    Senha = item.Senha,
                    ValorTorneio = item.ValorTorneio,
                    Id = item.Id,
                    NumeroJogadores = await _pagamentoRepository.JogadoresParticipante(item.Id)
                });
            }

            return CustomResponse(torneio.OrderBy(x => x.DataTorneio));
        }


        [HttpPost]
        public async Task<ActionResult<TorneioDto>> Adicionar(TorneioDto torneioDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!String.IsNullOrEmpty(torneioDto.DataTorneio))
            {
                var dateConvert = DateTime.ParseExact(torneioDto.DataTorneio, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));

                var torneio = new Torneio
                {
                    DataTorneio = dateConvert,
                    HorarioAbertura = torneioDto.HorarioAbertura,
                    HorarioInicio = torneioDto.HorarioInicio,
                    NomeTorneio = torneioDto.NomeTorneio,
                    Senha = torneioDto.Senha,
                    ValorTorneio = torneioDto.ValorTorneio
                };

                await _torneioRepository.Adicionar(torneio);
                return CustomResponse(torneioDto);
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<ActionResult<TorneioDto>> Deletar()
        {
            var torneio = await _torneioRepository.ObterTodos();

            if (torneio == null) return NotFound();

            foreach (var item in torneio)
            {
                if(item.DataTorneio != null)
                {
                    if (item.DataTorneio < DateTime.Now)
                    {
                        await _torneioService.Atualizar(new Torneio {
                            Id = item.Id,
                            Excluido = true,
                        });
                    }
                }
            }

            return CustomResponse();
        }
    }
}
