using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

using QAndA.Domain.Entities.Common;
using QAndA.Infrastructure.Extensions;

namespace QAndA.Infrastructure.Infrastructure.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static async void SetAuditProperties(this ChangeTracker changeTracker, ICurrentUserService currentUserService)
        {
            changeTracker.DetectChanges();
            IEnumerable<EntityEntry> entities =
                changeTracker
                    .Entries()
                    .Where(t => t.Entity is BaseDomainEntity &&
                    (
                        t.State == EntityState.Deleted
                        || t.State == EntityState.Added
                        || t.State == EntityState.Modified
                    ));

            if (entities.Any())
            {
                DateTime dateTime = DateTime.UtcNow;

                string user = await currentUserService.GetCurrentUserNameAsync();

                foreach (EntityEntry entry in entities)
                {
                    BaseDomainEntity entity = (BaseDomainEntity)entry.Entity;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.DateCreated = dateTime;
                            entity.CreatedBy = user;
                            entity.LastModifiedDate = dateTime;
                            entity.LastModifiedBy = user;
                            break;
                        case EntityState.Modified:
                            entity.LastModifiedDate = dateTime;
                            entity.LastModifiedBy = user;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            break;
                    }
                }
            }
        }
    }
}
