using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Persistance
{
    public interface IUnitOfWork:IDisposable
    {
        ILeaveTypeRepository leaveTypeRepository { get; }
        ILeaveRequestRepository leaveRequestRepository { get; }
        ILeaveAllocationRepository leaveAllocationRepository { get; }
        Task Save();
    }
}
