using AutoMapper;
using DevIO.Api.Controllers.Common;
using DevIO.Api.DTO;
using DevIO.Api.Extensions;
using DevIO.Business.DTO;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class JogadorController : MainController
    {
        private readonly IJogadorRepository _jogadorRepository;
        private readonly IJogadorService _jogadorService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public JogadorController(INotificador notificador,
                                    IMapper mapper,
                                    IJogadorRepository jogadorRepository,
                                    IJogadorService jogadorService,
                                    IUser user, UserManager<IdentityUser> userManager) : base(notificador, user)
        {
            _mapper = mapper;
            _jogadorRepository = jogadorRepository;
            _jogadorService = jogadorService;
            _userManager = userManager;
        }

        //[AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogadorDto>>> ObterTodos()
        {
            var jogadors = await _jogadorRepository.ObterTodos();

            var result = _jogadorService.Filter(jogadors);

            return CustomResponse(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<JogadorDto>>> ObterPorId(Guid id)
        {
            var jogadores = await _jogadorRepository.ObterTodos();
            var JogadorDto = jogadores.Find(x => x.Id == id);

            if (JogadorDto == null) return NotFound();

            return CustomResponse(JogadorDto);
        }

        [HttpPost]
        //[ClaimsAuthorize("jogador", "Inserir")]
        public async Task<ActionResult<JogadorDto>> Adicionar(JogadorDto JogadorDto)
        {
            
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var jogador = _mapper.Map<Jogador>(JogadorDto);
            await _jogadorService.Adicionar(jogador);

            return CustomResponse(JogadorDto);
        }


        [HttpPut("{id:guid}")]
        //[ClaimsAuthorize("jogador", "Alterar")]
        public async Task<ActionResult<JogadorDto>> Alterar(Guid id, JogadorPutDto jogadorDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var jogador = _mapper.Map<JogadorPutModelDto>(jogadorDto);
            await _jogadorService.Atualizar(jogador,id);

            if(!String.IsNullOrEmpty(jogadorDto.SenhaAntiga) && !String.IsNullOrEmpty(jogadorDto.NovaSenha))
            {
                var user = await _userManager.FindByEmailAsync(jogadorDto.Email);
                await _userManager.ChangePasswordAsync(user, jogadorDto.SenhaAntiga, jogadorDto.NovaSenha);
            } 

            return CustomResponse();
        }

        [HttpDelete("{id:guid}")]
        //[ClaimsAuthorize("Jogador", "Remover")]
        public async Task<ActionResult<JogadorDto>> Deletar(Guid id)
        {
            await _jogadorService.Remover(id);

            return CustomResponse();

        }

    }
}