using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QAndA.Domain.Entities;
using QAndA.Domain.Entities.IdentityEntities;
using QAndA.Infrastructure.Configurations;
using QAndA.Infrastructure.Extensions;
using QAndA.Infrastructure.Infrastructure.Extensions;

namespace QAndA.Infrastructure
{
    public class AppDbContext:IdentityDbContext<AppUser,IdentityRole,string>
    {
        private readonly ICurrentUserService _currentUserService;

        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService) :base(options) 
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Answer> Answers { get; set; }  
        public DbSet<Question> Questions { get; set; }  
        public DbSet<Post> Posts { get; set; }  
        public DbSet<AppUser> Users { get; set; }

     
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetAuditProperties(_currentUserService);
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            ChangeTracker.SetAuditProperties(_currentUserService);
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ChangeTracker.SetAuditProperties(_currentUserService);
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetAuditProperties(_currentUserService);
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
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
