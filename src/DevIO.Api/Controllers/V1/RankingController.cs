using AutoMapper;
using DevIO.Api.Controllers.Common;
using DevIO.Api.DTO;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    public class RankingController : MainController
    {
        private readonly IRankingService _rankingService;


        public RankingController(INotificador notificador,
                                 IRankingService rankingService,
                                 IUser user) : base(notificador, user)
        {
            _rankingService = rankingService;
        }

        [HttpGet()]
        public async Task<ActionResult<TorneioDto>> GetAllRanking()
        {
            var torneio = await _rankingService.Filter();

            if (torneio == null) return NotFound();

            return CustomResponse(torneio.OrderByDescending(x => x.Vitoria));
        }

        [HttpGet("Perfil/{id}")]
        public async Task<ActionResult<TorneioDto>> GetPerfil(string id)
        {
            try
            {
                var torneio = await _rankingService.GetPlayer(id);

                if (torneio == null) return NotFound();

                return CustomResponse(torneio);
            }
            catch (Exception)
            {
                NotificarErro("Perfil Jogador não encontrado.");
                return CustomResponse();
            }

        }

        [HttpGet("RankingById/{id}")]
        public async Task<ActionResult<ClashRoyaleRankingDto>> GetRankingById(string id)
        {
            try
            {
                var torneio = await _rankingService.GetRankingById(id);

                if (torneio == null) return NotFound();

                return CustomResponse(torneio);
            }
            catch (Exception err)
            {
                NotificarErro("Ranking não encontrado.");
                return CustomResponse();
            }

        }

        [HttpPut("UpdateRanking/{id}")]
        public async Task<ActionResult<ClashRoyaleRankingDto>> UpdateRanking(string id)
        {
            try
            {
                var torneio = await _rankingService.UpdateRanking(id);

                if (torneio == null) return NotFound();

                return CustomResponse(torneio);
            }
            catch (Exception err)
            {
                NotificarErro("Falha ao atualizar ranking.");
                return CustomResponse();
            }

        }
    }
}
