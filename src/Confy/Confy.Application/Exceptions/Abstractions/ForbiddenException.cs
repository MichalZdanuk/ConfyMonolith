namespace Confy.Application.Exceptions.Abstractions;
public abstract class ForbiddenException : Exception
{
	public ForbiddenException(string message) : base(message)
	{
	}
}
