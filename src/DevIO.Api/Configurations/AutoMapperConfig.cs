using AutoMapper;
using DevIO.Api.DTO;
using DevIO.Business.DTO;
using DevIO.Business.Models;

namespace DevIO.Api.Configurations
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Jogador, JogadorDto>().ReverseMap();
            CreateMap<JogadorPutModelDto, JogadorPutDto>().ReverseMap();
            CreateMap<Ranking, RankingDto>().ReverseMap();
            CreateMap<Pagamento, PagamentoDto>().ReverseMap();
            CreateMap<TorneioDto, Torneio>();
            CreateMap<Torneio, TorneioDto>();
        }
    }
}
