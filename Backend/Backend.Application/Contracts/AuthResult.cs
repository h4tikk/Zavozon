using Backend.Model.Models;

namespace Backend.Application.Contracts;

public record AuthResult(bool RegistrationRequired, string? AccessToken, Guid? UserId);

