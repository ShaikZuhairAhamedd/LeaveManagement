using HR.LeaveManagement.Domain.Common;
using System;

namespace HR.LeaveManagement.Domain
{
    public class LeaveType :BaseDomainEntity
    {
        public LeaveType(string name,int defaultDays)
        {
            this.Name = name;
            this.DefaultDays = defaultDays;
        }
     
        public string Name { get; set; }
        public int DefaultDays { get; set; }
   
    }
}
