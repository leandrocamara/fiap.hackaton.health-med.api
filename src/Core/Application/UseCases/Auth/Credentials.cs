namespace Application.UseCases.Auth;

public record Credentials(Guid UserId, string Role);

public static class Role
{
    public const string Patient = "Patient";
    public const string Doctor = "Doctor";
}