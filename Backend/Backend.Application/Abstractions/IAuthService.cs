using Backend.Application.Contracts;

namespace Backend.Application.Abstractions;

public interface IAuthService
{
    Task<AuthResult> AuthentificateAsync(string initData, CancellationToken cancellationToken);
    Task<AuthResult> RegisterAsync(string initData, string minecraftNickname, CancellationToken cancellationToken);
}