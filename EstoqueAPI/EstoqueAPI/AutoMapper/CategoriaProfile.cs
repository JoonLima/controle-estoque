using AutoMapper;
using EstoqueAPI.Contract.Categoria;
using EstoqueAPI.Domain.Models;

namespace EstoqueAPI.AutoMapper
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaRequestContract>().ReverseMap();
            CreateMap<Categoria, CategoriaResponseContract>().ReverseMap();
        }
    }
}
