namespace Confy.Application.Exceptions.Abstractions;
public abstract class NotFoundException : Exception
{
	public NotFoundException(string message) : base(message)
	{
	}
}
