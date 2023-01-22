using HR.LeaveManagement.Application.Constant;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeaveManagementDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private ILeaveTypeRepository _leaveTypeRepository;
        private ILeaveRequestRepository _leaveRequestRepository;

        public UnitOfWork(IHttpContextAccessor httpContextAccessor, LeaveManagementDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public ILeaveAllocationRepository leaveAllocationRepository =>
                  _leaveAllocationRepository ??= new LeaveAllocationRepository(_context);

        
        public ILeaveTypeRepository leaveTypeRepository =>
            _leaveTypeRepository ??= new LeaveTypeRepository(_context);

        
        public ILeaveRequestRepository leaveRequestRepository =>
            _leaveRequestRepository ??= new LeaveRequestRepository(_context);

        
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task Save()
        {
         
            await _context.SaveChangesAsync();
        }
    }
}
