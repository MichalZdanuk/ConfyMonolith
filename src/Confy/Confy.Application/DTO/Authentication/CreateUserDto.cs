using Confy.Domain.Enums;

namespace Confy.Application.DTO.Authentication;
public record CreateUserDto(string FirstName, string LastName, string Bio, string Email, string Password, UserRole UserRole);
