using AutoMapper;
using Common.DTO;
using Common.Entities;

namespace Common.Services.Infrastructure.MappingProfiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDTO>().ReverseMap();
            CreateMap<ArticleAddDTO, Article>().ReverseMap();
        }
    }
}