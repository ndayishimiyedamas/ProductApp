using Microsoft.EntityFrameworkCore;
namespace CommerceApp.Data
{
    public class CommerceContext: DbContext
    {
        public CommerceContext(DbContextOptions<CommerceContext> options) : base(options){}
        public DbSet<Models.Commerce> Commerces { get; set; }
    }
}