namespace Application.Feature.Hardware.Commands.CreateHardwareReservation;

public record CreateHardwareReservationCommand(HardwareReservationDto HardwareReservationDto) : ICommand<CreateHardwareReservationResult>;

public record CreateHardwareReservationResult(bool IsCreated, [property: JsonPropertyName("status")] StatusDto StatusDto);