using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagment.MVC.Services.Base
{
    public partial interface IClient
    {
        // <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveAllocationDto>> LeaveAllocationAllAsync();
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveAllocationDto>> LeaveAllocationsAllAsync(bool? isLoggedInUser);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveAllocationDto>> LeaveAllocationsAllAsync(bool? isLoggedInUser, System.Threading.CancellationToken cancellationToken);


        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveAllocationDto>> LeaveAllocationAllAsync(System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<BaseCommandResponse> LeaveAllocationPOSTAsync(CreateLeaveAllocationDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<BaseCommandResponse> LeaveAllocationPOSTAsync(CreateLeaveAllocationDto body, System.Threading.CancellationToken cancellationToken);


        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LeaveAllocationPUTAsync(UpdateLeaveAllocationDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LeaveAllocationPUTAsync(UpdateLeaveAllocationDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LeaveAllocationDto> LeaveAllocationGETAsync(int id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LeaveAllocationDto> LeaveAllocationGETAsync(int id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LeaveAllocationDELETEAsync(int id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LeaveAllocationDELETEAsync(int id, System.Threading.CancellationToken cancellationToken);

    }
}
