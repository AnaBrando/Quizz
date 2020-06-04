using CrossCutting.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrossCutting.Contexto
{
    public class UserDbContext : IdentityDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
         : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
