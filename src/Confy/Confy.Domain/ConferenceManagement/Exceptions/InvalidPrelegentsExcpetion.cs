namespace Confy.Domain.ConferenceManagement.Exceptions;
public class InvalidPrelegentsExcpetion
	: BadRequestException
{
	public InvalidPrelegentsExcpetion() : base($"Specified prelegents are invalid")
	{
	}
}
