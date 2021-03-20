using AutoMapper;
using DevIO.Api.Controllers.Common;
using DevIO.Api.DTO;
using DevIO.Api.Extensions;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoClienteRepository _enderecoRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(INotificador notificador,
                                    IMapper mapper,
                                    IClienteRepository clienteRepository,
                                    IEnderecoClienteRepository enderecoRepository,
                                    IClienteService clienteService,
                                    IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _clienteService = clienteService;
        }

        //[AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> ObterTodos()
        {
            var clientes = await _clienteRepository.ObterTodos();

            var result = _clienteService.Filter(clientes);

            return CustomResponse(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> ObterPorId(Guid id)
        {
            var ClienteDto = await ObterclienteProdutosEndereco(id);

            if (ClienteDto == null) return NotFound();

            return CustomResponse(ClienteDto);
        }

        [HttpPost]
        //[ClaimsAuthorize("cliente", "Inserir")]
        public async Task<ActionResult<ClienteDto>> Adicionar(ClienteDto ClienteDto)
        {
            
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var cliente = _mapper.Map<Cliente>(ClienteDto);
            await _clienteService.Adicionar(cliente);

            return CustomResponse(ClienteDto);
        }


        [HttpPut("{id:guid}")]
        //[ClaimsAuthorize("cliente", "Alterar")]
        public async Task<ActionResult<ClienteDto>> Alterar(Guid id, ClienteDto ClienteDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var dto = new ClienteDto
            {
                Celular = ClienteDto.Celular,
                ClienteAtivo = ClienteDto.ClienteAtivo,
                CNPJ = ClienteDto.CNPJ,
                CPF = ClienteDto.CPF,
                DataNascimento = ClienteDto.DataNascimento,
                Email = ClienteDto.Email,
                Id = id,
                InscricaoEstadual = ClienteDto.InscricaoEstadual,
                Nome = ClienteDto.Nome,
                Observacao = ClienteDto.Observacao,
                RG = ClienteDto.RG,
                Sobrenome = ClienteDto.Sobrenome,
                Telefone = ClienteDto.Telefone,
                TipoCliente = ClienteDto.TipoCliente,
                UserId = ClienteDto.UserId,
            };

            var cliente = _mapper.Map<Cliente>(dto);
            await _clienteService.Atualizar(cliente);

            return CustomResponse(dto);
        }

        [HttpDelete("{id:guid}")]
        //[ClaimsAuthorize("Cliente", "Remover")]
        public async Task<ActionResult<ClienteDto>> Deletar(Guid id)
        {

            var ClienteDto = await ObterclienteEndereco(id);

            if (ClienteDto == null) return NotFound();

            await _clienteService.Remover(id);

            return CustomResponse();

        }

        [HttpGet("obter-endereco/{id:guid}")]
        public async Task<ActionResult<IEnumerable<EnderecoClienteDto>>> ObterEnderecoPorId(Guid id)
        {
            var endereco = await _enderecoRepository.ObterPorId(id);
            var enderecoDto = _mapper.Map<EnderecoClienteDto>(endereco);

            return CustomResponse(enderecoDto);
        }

        [HttpPut("atualizar-endereco/{id:guid}")]
        [ClaimsAuthorize("cliente", "Alterar")]
        public async Task<ActionResult<IEnumerable<EnderecoClienteDto>>> AtualizarEndereco(Guid id, EnderecoClienteDto enderecoDto)
        {
            if (id != enderecoDto.Id)
            {
                NotificarErro("O identificador informado não corresponde");
                return CustomResponse(enderecoDto);
            }

            var endereco = _mapper.Map<EnderecoCliente>(enderecoDto);
            await _enderecoRepository.Atualizar(endereco);

            return CustomResponse(enderecoDto);
        }


        private async Task<ClienteDto> ObterclienteProdutosEndereco(Guid id)
        {
            var result = await _clienteRepository.ObterClienteProdutosEndereco(id);
            var cliente = _mapper.Map<ClienteDto>(result);
            return cliente;
        }

        private async Task<ClienteDto> ObterclienteEndereco(Guid id)
        {
            var result = await _clienteRepository.ObterClienteEndereco(id);
            var cliente = _mapper.Map<ClienteDto>(result);
            return cliente;
        }
    }
}