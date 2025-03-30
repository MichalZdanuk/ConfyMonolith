using Confy.Shared.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Confy.Infrastructure.Converters;
public class RegistrationStatusEnumConverter
	: ValueConverter<RegistrationStatus, string>
{
	public RegistrationStatusEnumConverter() : base(
			v => v.ToString(),
			v => (RegistrationStatus)Enum.Parse(typeof(RegistrationStatus), v))
	{ }
}
