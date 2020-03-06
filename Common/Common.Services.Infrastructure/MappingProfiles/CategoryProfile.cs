using AutoMapper;
using Common.DTO;
using Common.Entities;

namespace Common.Services.Infrastructure.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CategoryAddDTO, Category>().ReverseMap();
        }
    }
}