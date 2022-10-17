using Microsoft.EntityFrameworkCore;
using shoponline.api.Models;

namespace shoponline.api.data
{
    public class DatenDbContext : DbContext
    {
        public DatenDbContext(DbContextOptions<DatenDbContext> options) : base(options)
        {

        }
        public DbSet<Issue> Issues { get; set; }
    }
}
