using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QAndA.Domain.Entities;
using QAndA.Domain.Entities.Common;
using QAndA.Domain.Entities.IdentityEntities;
using QAndA.Infrastructure.Configurations;

namespace QAndA.Infrastructure
{
    public class AppDbContext:IdentityDbContext<AppUser,IdentityRole,string>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
                
        }

        public DbSet<Answer> Answers { get; set; }  
        public DbSet<Question> Questions { get; set; }  
        public DbSet<Post> Posts { get; set; }  
        public DbSet<AppUser> Users { get; set; }

        public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                entry.Entity.LastModifiedBy = username;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = username;
                }
            }

            var result = await base.SaveChangesAsync();

            return result;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
          
            var keysProperties = modelBuilder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
            foreach (var property in keysProperties)
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }
        }

    }
}
