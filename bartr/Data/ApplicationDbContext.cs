using
    Microsoft.AspNetCore.Identity.
    EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bartr.Data;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext>
        options)
    : IdentityDbContext<ApplicationUser>(options)
{
}
