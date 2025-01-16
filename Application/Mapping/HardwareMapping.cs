namespace Application.Mapping;

public class HardwareMapping : Profile
{
    public HardwareMapping()
    {
        CreateMap<HardwareReservationDto, HardwareReservation>().ReverseMap();
    }
}