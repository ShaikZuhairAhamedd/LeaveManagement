using HR.LeaveManagement.Application.Contracts.Persistence;

using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistance.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAllocation(List<LeaveAllocation> allocations)
        {
            await dbContext.AddRangeAsync(allocations);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await dbContext.leaveAllocations.AnyAsync(l => l.EmployeeId == userId && l.LeaveTypeId == leaveTypeId && l.Period == period);
        }

        public LeaveAllocation Get(string employeeId, int leaveTypeId)
        {
            return dbContext.leaveAllocations.Where(y => y.EmployeeId == employeeId && y.LeaveTypeId == leaveTypeId)
                                                 .FirstOrDefault();

        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            var leaveAllocation = await dbContext.leaveAllocations.Where(x => x.EmployeeId == userId)
                                              .Include(y => y.LeaveType)
                                              .ToListAsync();
            return leaveAllocation;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await dbContext.leaveAllocations
                                               .Include(x => x.LeaveType)
                                               .FirstOrDefaultAsync(x => x.Id == id);

            return leaveAllocation;

        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var result = await dbContext.leaveAllocations
                                       .Include(q => q.LeaveType)
                                       .ToListAsync();

            return result;
        }
        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await dbContext.leaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId
                                        && q.LeaveTypeId == leaveTypeId);
        }
    }
}
