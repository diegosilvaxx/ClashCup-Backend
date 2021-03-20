using AutoMapper;
using DevIO.Api.DTO;
using DevIO.Business.Models;

namespace DevIO.Api.Configurations
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Fornecedor, FornecedorDto>().ReverseMap();
            CreateMap<EnderecoCliente, EnderecoClienteDto>().ReverseMap();
            CreateMap<EnderecoFornecedor, EnderecoFornecedorDto>().ReverseMap();
            CreateMap<ProdutoDto, Produto>();
            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.NomeFantasia));
        }
    }
}
