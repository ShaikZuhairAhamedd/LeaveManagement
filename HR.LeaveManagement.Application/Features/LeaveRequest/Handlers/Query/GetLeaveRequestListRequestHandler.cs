using AutoMapper;
using HR.LeaveManagement.Application.Constant;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTO.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers
{
    public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUserService userService;

        public GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.mapper = mapper;
            mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userService = userService;
        }

        
        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
        {
            var leaveRequests = new List<HR.LeaveManagement.Domain.LeaveRequest>();
            var requests = new List<LeaveRequestListDto>();

            if (request.IsLoggedInUser)
            {
                var userId = httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;
                leaveRequests = await leaveRequestRepository.GetLeaveRequestsWithDetails(userId);

                var employee = await userService.GetEmployee(userId);
                requests = mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
                foreach (var req in requests)
                {
                    req.employee = employee;
                }
            }
            else
            {
                leaveRequests = await leaveRequestRepository.GetLeaveRequestWithDetails();
                requests = mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
                foreach (var req in requests)
                {
                    req.employee = await userService.GetEmployee(req.RequestingEmployeeId);
                }
            }

            return requests;
        }
    }
}
