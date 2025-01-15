
using Application.Feature.Events.Queries.GetEvents;
using Application.Feature.Events.Queries.GetEventsById;
using Application.Feature.Statistic.Queries.GetStatisticByEvent;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ADITUS.CodeChallenge.API
{
  [Route("events")]
  public class EventsController(
    ISender sender
  ) : ControllerBase
  {
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetEvents()
    {
      var events  = await sender.Send(new GetEventsQuery());
      return Ok(events);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetEvent(Guid id)
    {
      var eventDtoResult = await sender.Send(new GetEventByIdQuery(id));
      var statisticDtoResult = await sender.Send(new GetStatisticByEventQuery(eventDtoResult.Event.Id, eventDtoResult.Event.Type));
      
      eventDtoResult.Event = eventDtoResult.Event with { Statistic = statisticDtoResult.StatisticDto };
      return Ok(eventDtoResult);
    }
  }
}