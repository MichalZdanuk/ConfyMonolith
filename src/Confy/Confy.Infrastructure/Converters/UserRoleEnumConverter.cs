using Confy.Domain.Authentication.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Confy.Infrastructure.Converters;
public class UserRoleEnumConverter
	: ValueConverter<UserRole, string>
{
	public UserRoleEnumConverter() : base(
			v => v.ToString(),
			v => (UserRole)Enum.Parse(typeof(UserRole), v))
	{ }
}
