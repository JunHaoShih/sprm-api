using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SprmAuthentication.Core.AppUsers;
using SprmAuthentication.Core.Permissions;

namespace SprmAuthentication.EFs
{
    /// <summary>
    /// 驗證service DbContext
    /// </summary>
    public class AuthenticationContext : DbContext
    {
        /// <summary>
        /// Constructor, 一定要去base(options)
        /// </summary>
        /// <param name="options"></param>
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        { }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>()
                .HasIndex(c => new { c.UserId, c.ObjectTypeId })
                .IsUnique();

            modelBuilder.Entity<AppUser>()
                .Property(user => user.CustomValues)
                .HasDefaultValue(JsonSerializer.SerializeToDocument(new Dictionary<string, string>()));
        }

        /// <summary>
        /// AppUser
        /// </summary>
        public virtual DbSet<AppUser> AppUsers => Set<AppUser>();

        /// <summary>
        /// 權限
        /// </summary>
        public virtual DbSet<Permission> Permissions => Set<Permission>();
    }
}
