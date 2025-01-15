using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class StatisticMapping : Profile
{
    public StatisticMapping()
    {
        CreateMap<Statistic, Models.Dtos.StatisticDto>().ReverseMap();
    }
}