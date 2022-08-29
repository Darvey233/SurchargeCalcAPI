using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace GoFreightAPI.Models
{
    public class GoFreightContext : DbContext
    {
        public GoFreightContext(DbContextOptions<GoFreightContext> options)
            : base(options)
        {
        }

        public DbSet<GoFreightItem> GoFreightItems { get; set; } = null!;
    }
}