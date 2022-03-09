using Application.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ScaffoldContext : DbContext
    {
        public ScaffoldContext(DbContextOptions<ScaffoldContext> options) : base(options)
        {
            
        }

        public DbSet<CurrentQuotation> CurrentQuotations { get; set; }
    }
}
