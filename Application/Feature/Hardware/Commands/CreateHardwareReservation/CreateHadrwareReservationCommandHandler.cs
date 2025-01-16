namespace Application.Feature.Hardware.Commands.CreateHardwareReservation;

public class CreateHadrwareReservationCommandHandler(IHardwareService hardwareService, IMapper mapper)
    : ICommandHandler<CreateHardwareReservationCommand, CreateHardwareReservationResult>
{
    public async Task<CreateHardwareReservationResult> Handle(CreateHardwareReservationCommand request, CancellationToken cancellationToken)
    {
        var hardwareReservation = mapper.Map<HardwareReservation>(request.HardwareReservationDto);
        await hardwareService.HardwareReservation(hardwareReservation, request.HardwareReservationDto.Event);
        return new CreateHardwareReservationResult(true, new StatusDto(Guid.NewGuid(), Status.Pending));
    }
}