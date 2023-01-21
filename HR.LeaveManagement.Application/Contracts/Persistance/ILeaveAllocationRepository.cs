using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();

        Task<bool> AllocationExists(string userId,int leaveTypeId,int period);
        Task AddAllocation(List<LeaveAllocation> allocations);
        LeaveAllocation Get(string employeeId, int leaveTypeId);
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId);
        Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
        //Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    }
}
