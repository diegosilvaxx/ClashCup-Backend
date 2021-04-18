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
        private readonly IRankingRepository _rankingRepository;
        private readonly IRankingService _rankingService;
        private readonly IMapper _mapper;


        public RankingController(INotificador notificador,
                                 IMapper mapper,
                                 IRankingRepository rankingRepository,
                                 IRankingService rankingService,
                                 IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _rankingRepository = rankingRepository;
            _rankingService = rankingService;
        }

        [HttpGet()]
        public async Task<ActionResult<TorneioDto>> GetAllRanking()
        {
            var torneio = await _rankingService.Filter();

            if (torneio == null) return NotFound();

            return CustomResponse(torneio);
        }

        [HttpGet("Perfil/{id}")]
        public async Task<ActionResult<TorneioDto>> GetPerfil(string id)
        {
            var torneio = await _rankingService.GetPlayer(id);

            if (torneio == null) return NotFound();

            return CustomResponse(torneio);
        }
    }
}
