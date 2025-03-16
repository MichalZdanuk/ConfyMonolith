using Confy.Domain.Authentication;

namespace Confy.Application.Data;
public interface IApplicationDbContext
{
	Task<int> SaveChangesAsync();
}
