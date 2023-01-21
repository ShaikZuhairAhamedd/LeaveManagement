using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistance
{
   public class LeaveManagementDbContext :DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options):base(options)
        {

        }

        public DbSet<LeaveRequest> leaveRequests { get; set; }
        public DbSet<LeaveType> leaveTypes { get; set; }
        public DbSet<LeaveAllocation> leaveAllocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var listofEntityEntries = ChangeTracker.Entries<BaseDomainEntity>();
            foreach(var EntityEntry in listofEntityEntries) {
                EntityEntry.Entity.LastModifiedDate= DateTime.Now;
                if (EntityEntry.State == EntityState.Added) {
                    EntityEntry.Entity.DateCreated = DateTime.Now;
                 }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
