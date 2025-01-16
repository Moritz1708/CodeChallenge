namespace Application.Models;

public class HardwareReservationResultDto
{
    public bool IsReservationPossible { get; set; }
    public string Message { get; set; } = string.Empty;
    
    public static HardwareReservationResultDto Success(string message)
    {
        return new HardwareReservationResultDto
        {
            IsReservationPossible = true,
            Message = message
        };
    }
    
    public static HardwareReservationResultDto Success()
    {
        return new HardwareReservationResultDto
        {
            IsReservationPossible = true,
        };
    }
    
    public static HardwareReservationResultDto Failed(string message)
    {
        return new HardwareReservationResultDto
        {
            IsReservationPossible = false,
            Message = message
        };
    }
}