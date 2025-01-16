namespace ADITUS.CodeChallenge.API;

[Route("hardware")]
public class HardwareController(
    ISender sender
    ) : ControllerBase
{
    [HttpPost("reservation")]
    public async Task<IActionResult> CreateHardwareReservation([FromBody] HardwareReservationDto hardwareReservationDto)
    {
        var result = await sender.Send(new CreateHardwareReservationCommand(hardwareReservationDto));
        return Ok(result);
    }
    
    [HttpGet("reservation/status/{reservationStatusId}")]
    public async Task<IActionResult> GetStatusFromReservation([FromRoute] Guid reservationStatusId)
    {
        //Statusüberprüfungsprozess hier implementieren 
        //Mock Implementierung
        await Task.Delay(2000);
        var generator = new Random();
        var randomValue = generator.Next(1, 5);
        var status = randomValue switch
        {
            1 => new StatusDto(reservationStatusId, Status.Approved),
            2 => new StatusDto(reservationStatusId, Status.Cancelled),
            3 => new StatusDto(reservationStatusId, Status.Completed),
            4 => new StatusDto(reservationStatusId, Status.Pending),
            _ => new StatusDto(reservationStatusId, Status.Unknown)
        };
        return Ok(status);
    }
}