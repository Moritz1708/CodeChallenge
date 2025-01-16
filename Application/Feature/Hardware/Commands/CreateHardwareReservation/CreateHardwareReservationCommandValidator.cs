namespace Application.Feature.Hardware.Commands.CreateHardwareReservation;

public class CreateHardwareReservationCommandValidator : AbstractValidator<CreateHardwareReservationCommand>
{
    public CreateHardwareReservationCommandValidator()
    {
        RuleFor(x => x.HardwareReservationDto.Event).NotEmpty().WithMessage("The event id is required.");
        RuleFor(x => x.HardwareReservationDto.Menge).GreaterThan(0).WithMessage("The quantity must be greater than 0.");
        RuleFor(x => x.HardwareReservationDto.Hardware).NotNull().WithMessage("The hardware is required.");
        RuleFor(x => x.HardwareReservationDto.Event).Must(IsReservationDateValid).WithMessage("The reservation date is invalid.");
        RuleFor(x => x.HardwareReservationDto.Hardware).Must(IsHardwareAvailable).WithMessage("The hardware is not available.");
    }
    
    private static bool IsReservationDateValid(Event @event)
    {
        return DateTime.Now.AddDays(-28) > @event.StartDate;
    }
    
    private static bool IsHardwareAvailable(Domain.Entities.Hardware hardware)
    {
        //Hier sollte geprüft werden, ob das Hardware-Objekt verfügbar ist.
        //Mock implementierung
        /*
        {
        Check ob Hardware verfügbar ist und ob bereits Hardware für das Event gebucht wurde
        return HardwareUtil.CheckHardwareFormEvent(hardware, @event);
        }
        */
        return true;
    }
}