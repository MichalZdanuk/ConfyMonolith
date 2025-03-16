namespace Confy.Application.Data;
public interface IApplicationDbContext
{
	Task<int> SaveChangesAsync();
}
