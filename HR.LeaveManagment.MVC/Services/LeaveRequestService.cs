using AutoMapper;
using HR.LeaveManagment.MVC.Contracts;
using HR.LeaveManagment.MVC.Models;
using HR.LeaveManagment.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagment.MVC.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
       private IMapper _mapper { get; }


        public LeaveRequestService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            mapper = mapper;
        }

        public async Task ApproveLeaveRequest(int id, bool approved)
        {
            AddBearerToken();
            try
            {
                var request = new ChangeLeaveRequestApprovalDto { Approved = approved, Id = id };
                await _client.ChangeapprovalAsync(id, request);
            }
            catch (Exception ex)
            {

            }

        }

        public async Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVM leaveRequest)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveRequestDto createLeaveRequest = new CreateLeaveRequestDto { EndDate = leaveRequest.EndDate, StartDate = leaveRequest.StartDate, LeaveTypeId = leaveRequest.LeaveTypeId, RequestComments = leaveRequest.RequestComments };
                AddBearerToken();
                var apiResponse = await _client.LeaveRequestsPOSTAsync(createLeaveRequest);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public Task DeleteLeaveRequest(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            AddBearerToken();
            var leaveRequests = await _client.LeaveRequestsAllAsync(isLoggedInUser: false);

            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                PendingRequests = leaveRequests.Count(q => q.Approved == null),
                RejectedRequests = leaveRequests.Count(q => q.Approved == false),
                LeaveRequests = leaveRequests.Select(x => new LeaveRequestVM {
                        Id=x.Id,
                        Approved=x.Approved,
                        DateRequested=x.DateRequested.DateTime,
                        StartDate=x.StartDate.DateTime,
                        EndDate=x.EndDate.DateTime,
                        LeaveType=new LeaveTypeVM { 
                       DefaultDays=x.LeaveType.DefaultDays,
                       Name=x.LeaveType.Name
                     
                       
                        },
                        Employee=new EmployeeVM { 
                        Firstname=x.RequestingEmployeeId
                        }


                }).ToList()
            };
            return model;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetUserLeaveRequests()
        {
            AddBearerToken();
            var leaveRequests = await _client.LeaveRequestsAllAsync(isLoggedInUser: true);
            var allocations = await _client.LeaveAllocationsAllAsync(isLoggedInUser: true);

            // Continue From 10. vide....

            var model = new EmployeeLeaveRequestViewVM
            {
                LeaveAllocations = _mapper.Map<List<LeaveAllocationVM>>(allocations),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };
            return model; 
        }

        public async Task<LeaveRequestVM> GetLeaveRequest(int id)
        {
            AddBearerToken();
            var leaveRequest = await _client.LeaveRequestsGETAsync(id);
            return new LeaveRequestVM { 
            Id=leaveRequest.Id,
            DateRequested=leaveRequest.DateRequested.DateTime,
            StartDate=leaveRequest.StartDate.DateTime,
            EndDate=leaveRequest.EndDate.DateTime,
            Approved=leaveRequest.Approved,
            Cancelled=leaveRequest.Cancelled,
            DateActioned=!leaveRequest.DateActioned.HasValue?DateTime.Now:leaveRequest.DateActioned.Value.DateTime,
            Employee=new EmployeeVM { 
            Firstname=leaveRequest.Employee.Firstname,
            Lastname=leaveRequest.Employee.Lastname,
            Email=leaveRequest.Employee.Email
            },
            LeaveType=new LeaveTypeVM { 
            Name=leaveRequest.LeaveType.Name,
            DefaultDays=leaveRequest.LeaveType.DefaultDays,
            Id=leaveRequest.LeaveType.Id
            }
            


            };
        }
    }
}

