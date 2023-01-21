//public partial interface IClient
//{
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<AuthResponse> LoginAsync(AuthRequest body);

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<AuthResponse> LoginAsync(AuthRequest body, System.Threading.CancellationToken cancellationToken);

//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<AuthResponse> RegisterAsync(RegistrationRequest body);

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<AuthResponse> RegisterAsync(RegistrationRequest body, System.Threading.CancellationToken cancellationToken);

//    /// <returns>Success</returns>
//    /
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveRequestListDto>> LeaveRequestsAllAsync(bool? isLoggedInUser);

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveRequestListDto>> LeaveRequestsAllAsync(bool? isLoggedInUser, System.Threading.CancellationToken cancellationToken);

//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<BaseCommandResponse> LeaveRequestsPOSTAsync(CreateLeaveRequestDto body);

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<BaseCommandResponse> LeaveRequestsPOSTAsync(CreateLeaveRequestDto body, System.Threading.CancellationToken cancellationToken);

//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<LeaveRequestDto> LeaveRequestsGETAsync(int id);

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<LeaveRequestDto> LeaveRequestsGETAsync(int id, System.Threading.CancellationToken cancellationToken);

//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task LeaveRequestsPUTAsync(int id, UpdateLeaveRequestDto body);

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task LeaveRequestsPUTAsync(int id, UpdateLeaveRequestDto body, System.Threading.CancellationToken cancellationToken);

//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task LeaveRequestsDELETEAsync(int id);

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task LeaveRequestsDELETEAsync(int id, System.Threading.CancellationToken cancellationToken);

//    System.Threading.Tasks.Task ChangeapprovalAsync(int id, ChangeLeaveRequestApprovalDto body);

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref="ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task ChangeapprovalAsync(int id, ChangeLeaveRequestApprovalDto body, System.Threading.CancellationToken cancellationToken);


//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveTypeDto>> LeaveTypesAllAsync();

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveTypeDto>> LeaveTypesAllAsync(System.Threading.CancellationToken cancellationToken);

//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<BaseCommandResponse> LeaveTypesPOSTAsync(CreateLeaveTypeDto body);

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<BaseCommandResponse> LeaveTypesPOSTAsync(CreateLeaveTypeDto body, System.Threading.CancellationToken cancellationToken);

//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<LeaveTypeDto> LeaveTypesGETAsync(int id);

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<LeaveTypeDto> LeaveTypesGETAsync(int id, System.Threading.CancellationToken cancellationToken);

//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task LeaveTypesPUTAsync(int id, LeaveTypeDto body);
//    A
//        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//        /// <returns>Success</returns>
//        /// <exception cref=" ApiException">A server side error occurred.</exception>
//        System.Threading.Tasks.Task LeaveTypesPUTAsync(int id, LeaveTypeDto body, System.Threading.CancellationToken cancellationToken);

//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task LeaveTypesDELETEAsync(int id);

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task LeaveTypesDELETEAsync(int id, System.Threading.CancellationToken cancellationToken);

//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<System.Collections.Generic.ICollection<WeatherForecast>> WeatherForecastAsync();

//    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//    /// <returns>Success</returns>
//    /// <exception cref=" ApiException">A server side error occurred.</exception>
//    System.Threading.Tasks.Task<System.Collections.Generic.ICollection<WeatherForecast>> WeatherForecastAsync(System.Threading.CancellationToken cancellationToken);

//}
