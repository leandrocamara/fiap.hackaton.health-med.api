namespace Application.UseCases.Auth;

public record Credentials(Guid UserId, Profile Profile);

public enum Profile
{
    Patient,
    Doctor
}