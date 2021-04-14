using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.DTO;
using DevIO.Business.Models;
using DevIO.Business.Services;

namespace DevIO.Business.Intefaces
{
    public interface IJogadorService : IDisposable
    {
        Task<bool> Adicionar(Jogador cliente);
        Task<bool> Atualizar(JogadorPutModelDto cliente, Guid id);
        List<JogadorFilterDto> Filter(List<Jogador> cliente);
        Task<bool> Remover(Guid id);
        Task<Guid> GetById(string id);
        Task<string> GetIdClashById(string id);
    }
}