using AutoMapper;
using EstoqueAPI.Contract.Produto;
using EstoqueAPI.Domain.Models;

namespace EstoqueAPI.AutoMapper
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoRequestContract>().ReverseMap();
            CreateMap<Produto, ProdutoResponseContract>().ReverseMap();
        }
    }
}
