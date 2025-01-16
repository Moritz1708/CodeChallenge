namespace Application.Services.Hardware;

public class HardwareService : IHardwareService
{
    //Reservation mock
    public async Task HardwareReservation(HardwareReservation hardwareReservation, Event @event)
    {
        await Task.Delay(2000);
    }
}