using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.DTO;
using DevIO.Business.Models;
using DevIO.Business.Services;

namespace DevIO.Business.Intefaces
{
    public interface IRankingService 
    {
        Task<List<RankingModelDto>> Filter();
        Task<ClashRoyaleDto> GetPlayer(string idClash);
    }
}