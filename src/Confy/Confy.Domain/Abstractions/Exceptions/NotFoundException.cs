namespace Confy.Domain.Abstractions.Exceptions;
public abstract class NotFoundException : Exception
{
	public NotFoundException(string message) : base(message)
	{
	}
}
