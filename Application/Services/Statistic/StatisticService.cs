namespace Application.Services.Statistic;

public class StatisticService(IHttpClientFactory httpClientFactory, IMapper mapper) : IStatisticService
{
    public async Task<List<Domain.Entities.Statistic>> GetStatisticFromEvent(Guid eventId, EventType eventType)
    {
        var httpClient = httpClientFactory.CreateClient(ServiceNameConfiguration.ServiceConfigurationName);

        if (eventType == EventType.Hybrid)
        {
            var onlineStatisticTask =  httpClient.GetAsync($"/api/{ServiceNameConfiguration.OnlineStatisticPath}/{eventId}");
            var onSiteStatisticTask =  httpClient.GetAsync($"/api/{ServiceNameConfiguration.OnSiteStatisticPath}/{eventId}");
            
            await Task.WhenAll(onlineStatisticTask, onSiteStatisticTask);
            
            var onlineStatisticResponse = await onlineStatisticTask;
            var onSiteStatisticResponse = await onSiteStatisticTask;
            
            var onlineStatistic = await HandleResponse<Domain.Entities.Statistic>(onlineStatisticResponse);
            var onSiteStatistic = await HandleResponse<Domain.Entities.Statistic>(onSiteStatisticResponse);
            return [onlineStatistic, onSiteStatistic];
        }
        var urlPath = eventType == EventType.Online 
            ? ServiceNameConfiguration.OnlineStatisticPath 
            : ServiceNameConfiguration.OnSiteStatisticPath;
        
        var response = await httpClient.GetAsync($"/api/{urlPath}/{eventId}");

        return [await HandleResponse<Domain.Entities.Statistic>(response)];
    }
    
    private static async Task<T>HandleResponse<T>(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to get statistic from event");
        }
        
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content) ?? throw new Exception("Failed to deserialize content");
    }
}