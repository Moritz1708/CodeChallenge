﻿
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class EventMapping : Profile
{
    public EventMapping()
    {
        CreateMap<Event, Models.Dtos.EventDto>().ReverseMap();
    }
}