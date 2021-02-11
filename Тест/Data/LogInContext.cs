using Microsoft.EntityFrameworkCore;
using Тест.Models;

namespace Тест.Data
{
    public class LogInContext : DbContext
    {
        public LogInContext(DbContextOptions<LogInContext> options)
            : base(options)
        {
        }

        public DbSet<LogIn> LogIn { get; set; }
    }
}
