using AutoMapper;
using News.Application.Dto;
using News.Domain.Entities;

namespace News.Application.Profiles;

public class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<ArticleDto, Article>();
        CreateMap<ArticleUpdateDto, Article>().ReverseMap();

    }
}