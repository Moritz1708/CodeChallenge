using Domain.Entities;
using Newtonsoft.Json;

namespace Application.Models.Dtos;


public record StatusDto(Guid ReservationId, Status Status);