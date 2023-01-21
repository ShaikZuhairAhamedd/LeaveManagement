using HR.LeaveManagement.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Request.Query

{
    public class GetLeaveTypeListRequest:IRequest<List<LeaveTypeDto>>
    {
    }
}
