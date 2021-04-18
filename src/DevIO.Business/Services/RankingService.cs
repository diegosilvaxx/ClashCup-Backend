using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DevIO.Business.DTO;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DevIO.Business.Services
{
    public class RankingService :IRankingService
    {
        private readonly IRankingRepository _rankingRepository;
        private readonly IConfiguration _configuration;

        public RankingService(IRankingRepository rankingRepository, IConfiguration configuration)
        {
            _rankingRepository = rankingRepository;
            _configuration = configuration;
        }

        public async Task<List<RankingModelDto>> Filter()
        {
            List<RankingModelDto> listRanking = new List<RankingModelDto>();

            var rankingResult = await _rankingRepository.GetAllRanking();

            
            foreach (var item in rankingResult)
            {
                var result = await GetPlayer(item.IdClash);
                if (result.Name != null)
                {
                    listRanking.Add(new RankingModelDto
                    {
                        Arena = result.Arena.Name,
                        Cla = result.Clan.Name,
                        Player = result.Name,
                        Trofeu = result.Trophies,
                        Vitoria = item.Vitoria,
                        Nome = item.Nome,
                        IdClash = item.IdClash,
                    });
                }
                else
                {
                    listRanking.Add(new RankingModelDto
                    {
                        Vitoria = item.Vitoria,
                        Nome = item.Nome,
                        IdClash = item.IdClash,
                    });
                }

            }

            return listRanking;
        }

        public async Task<ClashRoyaleDto> GetPlayer(string idClash)
        {
            HttpClient client = new HttpClient();

            var token = _configuration.GetSection("ClashAPI").GetSection("token").Value;
            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);



            client.BaseAddress = new Uri($"https://api.clashroyale.com/v1/players/%23{idClash.Replace("#","")}");

            var result = await client.GetAsync(client.BaseAddress);

            var resultRead = await result.Content.ReadAsStringAsync();

            var resultClash = JsonConvert.DeserializeObject<ClashRoyaleDto>(resultRead);
            return resultClash;
        }

    }
}