using Microsoft.EntityFrameworkCore;
using QAndA.Domain.Entities;
using QAndA.Domain.Entities.IdentityEntities;

namespace QAndA.Infrastructure
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
                
        }

        public DbSet<Answer> Answers { get; set; }  
        public DbSet<Question> Questions { get; set; }  
        public DbSet<Post> Posts { get; set; }  
        public DbSet<AppUser> Users { get; set; }





    }
}
