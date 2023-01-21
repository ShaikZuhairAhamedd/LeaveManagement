using HR.LeaveManagment.MVC.Models;
using HR.LeaveManagment.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagment.MVC.Contracts
{
    public interface ILeaveRequestService
    {
        Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVM leaveRequestVM);
        Task ApproveLeaveRequest(int id, bool approved);
        Task DeleteLeaveRequest(int id);
        Task<EmployeeLeaveRequestViewVM> GetUserLeaveRequests();
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
        Task<LeaveRequestVM> GetLeaveRequest(int id);
    }
}
