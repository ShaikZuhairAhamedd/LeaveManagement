using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagment.MVC.Services.Base
{
    public partial interface IClient
    {
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveTypeDto>> LeaveTypesAllAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveTypeDto>> LeaveTypesAllAsync(System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<BaseCommandResponse> LeaveTypesPOSTAsync(CreateLeaveTypeDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<BaseCommandResponse> LeaveTypesPOSTAsync(CreateLeaveTypeDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LeaveTypeDto> LeaveTypesGETAsync(int id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LeaveTypeDto> LeaveTypesGETAsync(int id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LeaveTypesPUTAsync(int id, LeaveTypeDto body);
        
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LeaveTypesPUTAsync(int id, LeaveTypeDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LeaveTypesDELETEAsync(int id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LeaveTypesDELETEAsync(int id, System.Threading.CancellationToken cancellationToken);

    }
}
