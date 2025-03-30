namespace Confy.Domain.Abstractions.Exceptions;
public abstract class BadRequestException : Exception
{
	public BadRequestException(string message) : base(message)
	{
	}
}
