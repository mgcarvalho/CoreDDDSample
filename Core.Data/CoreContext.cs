namespace Core.Data
{
    using Microsoft.EntityFrameworkCore;
    using Core.Domain.Entity;

    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions options) : base(options){}


        public DbSet<User> Users { get; set; }
        
        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

    }
}
