using Microsoft.EntityFrameworkCore;

namespace MVCDocker.Data
{
    public class MvcDockerContext : DbContext
    {
        public MvcDockerContext(DbContextOptions<MvcDockerContext> options) 
            : base (options)
        {
        }

        public DbSet<Models.Planets> Planets { get; set; }
    }
}
