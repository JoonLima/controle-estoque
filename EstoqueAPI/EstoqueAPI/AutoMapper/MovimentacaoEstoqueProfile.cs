using AutoMapper;
using EstoqueAPI.Contract.MovimentacaoEstoque;
using EstoqueAPI.Domain.Models;

namespace EstoqueAPI.AutoMapper
{
    public class MovimentacaoEstoqueProfile : Profile
    {
        public MovimentacaoEstoqueProfile()
        {
            CreateMap<MovimentacaoEstoque, MovimentacaoEstoqueRequestContract>().ReverseMap();
            CreateMap<MovimentacaoEstoque, MovimentacaoEstoqueResponseContract>().ReverseMap();
        }
    }
}
