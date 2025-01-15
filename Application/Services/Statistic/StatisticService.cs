using Application.Configuration;
using Application.Models.Dtos;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Services.Statistic;
using Newtonsoft.Json;

namespace Application.Services.Statistic;

public class StatisticService(IHttpClientFactory httpClientFactory, IMapper mapper) : IStatisticService
{
    public async Task<Domain.Entities.Statistic> GetStatisticFromEvent(Guid eventId, EventType eventType)
    {
        var httpClient = httpClientFactory.CreateClient(ServiceNameConfiguration.ServiceConfigurationName);
        
        var urlPath = eventType == EventType.Online 
            ? ServiceNameConfiguration.OnlineStatisticPath 
            : ServiceNameConfiguration.OnSiteStatisticPath;
        
        var response = await httpClient.GetAsync($"/api/{urlPath}/{eventId}");
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to get statistic from event");
        }
        
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Domain.Entities.Statistic>(content) ?? throw new Exception("Failed to deserialize statistic");
    }
}