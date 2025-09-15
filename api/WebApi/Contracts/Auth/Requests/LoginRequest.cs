namespace WebApi.Contracts.Auth.Requests;

public class LoginRequest
{
    public string Email { get; set; }
    public string UID { get; set; }
    public string? Name { get; set; }
    public string? PhotoUrl { get; set; }
}