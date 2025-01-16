namespace Infrastructure.Services.Hardware;

public interface IHardwareService
{
    Task HardwareReservation(HardwareReservation hardwareReservation, Event @event);
}