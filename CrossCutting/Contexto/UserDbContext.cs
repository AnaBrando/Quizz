using CrossCutting.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrossCutting.Contexto
{
    public class UserDbContext : IdentityDbContext<Usuario>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
         : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            //=> options.UseSqlServer(@"Data Source=DESKTOP-OJVFABH\SQLEXPRESS;Initial Catalog=Quizz;Integrated Security=True;");

        => options.UseSqlServer(@"Server=tcp:127.0.0.1,1433;Database=Quizz;UID=SA;PWD=myPass123");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
