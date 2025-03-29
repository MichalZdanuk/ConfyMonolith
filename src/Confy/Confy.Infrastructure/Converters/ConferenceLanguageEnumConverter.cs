using Confy.Shared.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Confy.Infrastructure.Converters;
public class ConferenceLanguageEnumConverter
	: ValueConverter<ConferenceLanguage, string>
{
	public ConferenceLanguageEnumConverter() : base(
			v => v.ToString(),
			v => (ConferenceLanguage)Enum.Parse(typeof(ConferenceLanguage), v))
	{ }
}
