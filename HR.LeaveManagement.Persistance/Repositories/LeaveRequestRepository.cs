using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace HR.LeaveManagement.Persistance.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext dbContext;

        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approved)
        {
            leaveRequest.Approved = approved;
            dbContext.Entry(leaveRequest).State = EntityState.Modified;
            
        }


        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            var result = await dbContext.leaveRequests.Where(x => x.RequestingEmployeeId == userId)
                                                      .Include(x => x.LeaveType)
                                                      .ToListAsync();
            return result;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int Id)
        {

            var leaveReqeust = await dbContext.leaveRequests
                                           .Include(lr => lr.LeaveType)
                                           .FirstOrDefaultAsync(lr=>lr.Id==Id);
            return leaveReqeust;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveReqeusts = await dbContext.leaveRequests
                                           .Include(lr => lr.LeaveType)
                                           .ToListAsync();
            return leaveReqeusts;
        }
    }
}
