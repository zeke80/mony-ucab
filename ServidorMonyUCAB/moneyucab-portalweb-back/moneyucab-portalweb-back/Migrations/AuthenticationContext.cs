

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using moneyucab_portalweb_back.EntitiesForm;

namespace moneyucab_portalweb_back.Migrations
{
    public class AuthenticationContext : IdentityDbContext<Usuario>
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
