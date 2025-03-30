namespace Confy.Application.Context;
public interface IContext
{
	Guid UserId { get; }
	string Role { get; }
}
