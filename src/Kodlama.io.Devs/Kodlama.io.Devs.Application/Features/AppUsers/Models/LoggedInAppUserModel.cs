namespace Kodlama.io.Devs.Application.Features.AppUsers.Models;

public class LoggedInAppUserModel
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}