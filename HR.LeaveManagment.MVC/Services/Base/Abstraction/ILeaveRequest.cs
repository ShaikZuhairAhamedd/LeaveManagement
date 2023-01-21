using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagment.MVC.Services.Base
{
    public partial interface IClient
    {
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveRequestListDto>> LeaveRequestsAllAsync(bool? isLoggedInUser);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveRequestListDto>> LeaveRequestsAllAsync(bool? isLoggedInUser, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<BaseCommandResponse> LeaveRequestsPOSTAsync(CreateLeaveRequestDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<BaseCommandResponse> LeaveRequestsPOSTAsync(CreateLeaveRequestDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LeaveRequestDto> LeaveRequestsGETAsync(int id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LeaveRequestDto> LeaveRequestsGETAsync(int id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LeaveRequestsPUTAsync(int id, UpdateLeaveRequestDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LeaveRequestsPUTAsync(int id, UpdateLeaveRequestDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LeaveRequestsDELETEAsync(int id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LeaveRequestsDELETEAsync(int id, System.Threading.CancellationToken cancellationToken);

        System.Threading.Tasks.Task ChangeapprovalAsync(int id, ChangeLeaveRequestApprovalDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ChangeapprovalAsync(int id, ChangeLeaveRequestApprovalDto body, System.Threading.CancellationToken cancellationToken);

    }

}
