using System.Text.Json;
using Microsoft.EntityFrameworkCore;

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
        }
    }
}
