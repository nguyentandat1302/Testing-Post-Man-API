using Microsoft.EntityFrameworkCore;

namespace Testing_Post_Man_API.Models
{
    public class ApiDemoDbContext : DbContext
    {
        public ApiDemoDbContext(DbContextOptions<ApiDemoDbContext> options) : base(options) 
        {

        }
        public DbSet<Users> users { get; set; }  
    }
}
