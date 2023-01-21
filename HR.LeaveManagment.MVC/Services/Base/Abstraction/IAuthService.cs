using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagment.MVC.Services.Base
{
    public partial interface IClient
    {
        System.Threading.Tasks.Task<AuthResponse> LoginAsync(AuthRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<AuthResponse> LoginAsync(AuthRequest body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<AuthResponse> RegisterAsync(RegistrationRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref=" ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<AuthResponse> RegisterAsync(RegistrationRequest body, System.Threading.CancellationToken cancellationToken);

    }
}
