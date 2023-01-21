using HR.LeaveManagment.MVC.Contracts;
using HR.LeaveManagment.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagment.MVC.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
    {
       

        public LeaveAllocationService(IClient client, ILocalStorageService localStorage):base(client,localStorage)
        {
        }
        public async Task<Response<int>> CreateLeaveAllocations(int leaveTypeId)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveAllocationDto createLeaveAllocationDto = new CreateLeaveAllocationDto { LeaveTypeId = leaveTypeId };
                AddBearerToken();
                 var ApiResponse=  await _client.LeaveAllocationPOSTAsync(createLeaveAllocationDto);
                if (ApiResponse.Success)
                {
                    response.Success = true;
                }
                return response;
            }
            catch (ApiException ex) {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
