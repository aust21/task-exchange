using Microsoft.AspNetCore.Identity;

namespace bartr.Data;

public class User:IdentityUser
{
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DateCreated { get; set; }
}
