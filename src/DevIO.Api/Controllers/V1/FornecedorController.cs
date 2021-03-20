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
using System.Threading.Tasks;

namespace DevIO.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FornecedorController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoFornecedorRepository _enderecoRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedorController(INotificador notificador,
                                    IMapper mapper,
                                    IFornecedorRepository fornecedorRepository,
                                    IEnderecoFornecedorRepository enderecoRepository,
                                    IFornecedorService fornecedorService,
                                    IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
            _fornecedorService = fornecedorService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorDto>>> ObterTodos()
        {
            var fornecedores = await _fornecedorRepository.ObterTodos();
            var result = _fornecedorService.Filter(fornecedores);

            return CustomResponse(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<FornecedorDto>>> ObterPorId(Guid id)
        {
            var fornecedorDto = await ObterFornecedorProdutosEndereco(id);

            if (fornecedorDto == null) return NotFound();

            return CustomResponse(fornecedorDto);
        }

        [HttpPost]
        //[ClaimsAuthorize("Fornecedor", "Inserir")]
        public async Task<ActionResult<FornecedorDto>> Adicionar(FornecedorDto fornecedorDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
            await _fornecedorService.Adicionar(fornecedor);

            return CustomResponse(fornecedorDto);
        }


        [HttpPut("{id:guid}")]
        //[ClaimsAuthorize("Fornecedor", "Alterar")]
        public async Task<ActionResult<FornecedorDto>> Alterar(Guid id, FornecedorDto fornecedorDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
            await _fornecedorService.Atualizar(fornecedor);

            return CustomResponse(fornecedorDto);
        }

        [HttpDelete("{id:guid}")]
        //[ClaimsAuthorize("Fornecedor", "Remover")]
        public async Task<ActionResult<FornecedorDto>> Deletar(Guid id)
        {

            var fornecedorDto = await ObterFornecedorEndereco(id);

            if (fornecedorDto == null) return NotFound();

            await _fornecedorService.Remover(id);

            return CustomResponse();

        }

        [HttpGet("obter-endereco/{id:guid}")]
        public async Task<ActionResult<IEnumerable<EnderecoFornecedorDto>>> ObterEnderecoPorId(Guid id)
        {
            var endereco = await _enderecoRepository.ObterPorId(id);
            var enderecoDto = _mapper.Map<EnderecoFornecedorDto>(endereco);

            return CustomResponse(enderecoDto);
        }

        [HttpPut("atualizar-endereco/{id:guid}")]
        //[ClaimsAuthorize("Fornecedor", "Alterar")]
        public async Task<ActionResult<IEnumerable<EnderecoFornecedorDto>>> AtualizarEndereco(Guid id, EnderecoFornecedorDto enderecoDto)
        {
            if (id != enderecoDto.Id)
            {
                NotificarErro("O identificador informado não corresponde");
                return CustomResponse(enderecoDto);
            }

            var endereco = _mapper.Map<EnderecoFornecedor>(enderecoDto);
            await _enderecoRepository.Atualizar(endereco);

            return CustomResponse(enderecoDto);
        }


        private async Task<FornecedorDto> ObterFornecedorProdutosEndereco(Guid id)
        {
            var result = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);
            var fornecedor = _mapper.Map<FornecedorDto>(result);
            return fornecedor;
        }

        private async Task<FornecedorDto> ObterFornecedorEndereco(Guid id)
        {
            var result = await _fornecedorRepository.ObterFornecedorEndereco(id);
            var fornecedor = _mapper.Map<FornecedorDto>(result);
            return fornecedor;
        }
    }
}