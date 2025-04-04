namespace Confy.Domain.ConferenceManagement.Exceptions;
public class LectureDatesCollisionException
	: BadRequestException
{
	public LectureDatesCollisionException() : base("Ivalid combination of StartDate and EndDate")
	{
	}
}
