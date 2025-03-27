namespace Confy.Application.Exceptions.ConferenceManagement;
public class InvalidPrelegentsExcpetion
	: BadRequestException
{
	public InvalidPrelegentsExcpetion() : base($"Specified prelegents are invalid")
	{
	}
}
