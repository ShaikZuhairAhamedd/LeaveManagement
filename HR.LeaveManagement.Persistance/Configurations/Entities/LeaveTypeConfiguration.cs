using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistance.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        

        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                 new LeaveType("Vacation", 10) { Id=1}
                ,
                 new LeaveType("Sick", 12) { Id=2}
                 
             );
        }
    }
}
