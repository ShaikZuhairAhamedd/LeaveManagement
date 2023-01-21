using HR.LeaveManagement.Application.DTO.Common;
using HR.LeaveManagement.Application.Modals.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTO
{
    public class LeaveAllocationDto: BaseDto
    {
        public string EmployeeId;
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public Employee Employee { get; internal set; }
    }
}
