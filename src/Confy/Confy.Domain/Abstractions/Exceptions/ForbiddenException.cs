namespace Confy.Domain.Abstractions.Exceptions;
public abstract class ForbiddenException : Exception
{
	public ForbiddenException(string message) : base(message)
	{
	}
}
