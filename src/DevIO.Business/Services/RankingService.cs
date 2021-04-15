using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DevIO.Business.DTO;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using Newtonsoft.Json;

namespace DevIO.Business.Services
{
    public class RankingService :IRankingService
    {
        private readonly IRankingRepository _rankingRepository;

        public RankingService(IRankingRepository rankingRepository)
        {
            _rankingRepository = rankingRepository;
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
            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjM2NDQ2OTc1LWVmMTgtNDJmZS1iZDUzLTdlOGE3ZWYzNzI2ZCIsImlhdCI6MTYxODM2MjE3NSwic3ViIjoiZGV2ZWxvcGVyLzIyNmVkM2NlLWUwYTYtOWE5My1lYzZiLTY0Yzg5OTZiZGJmYyIsInNjb3BlcyI6WyJyb3lhbGUiXSwibGltaXRzIjpbeyJ0aWVyIjoiZGV2ZWxvcGVyL3NpbHZlciIsInR5cGUiOiJ0aHJvdHRsaW5nIn0seyJjaWRycyI6WyIxOTEuNi4yMTguMTI1Il0sInR5cGUiOiJjbGllbnQifV19.unfX931FP3pQ3J9o3spAcGuq70z0banla982E63AcFo5MnGYHuvYv7RH-Q06oeZ02_ruhK2vI5ef_wW90xyM5A");

            client.BaseAddress = new Uri($"https://api.clashroyale.com/v1/players/%23{idClash.Replace("#","")}");

            var result = await client.GetAsync(client.BaseAddress);

            var resultRead = await result.Content.ReadAsStringAsync();

            var resultClash = JsonConvert.DeserializeObject<ClashRoyaleDto>(resultRead);
            return resultClash;
        }

    }
}