namespace Application.UseCases.Auth;

public record Credentials(Guid UserId, List<string> Roles);

public static class Role
{
    public const string Patient = "Patient";
    public const string Doctor = "Doctor";
}