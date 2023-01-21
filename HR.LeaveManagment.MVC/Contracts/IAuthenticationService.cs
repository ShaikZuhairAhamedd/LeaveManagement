using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagment.MVC.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);

        Task<bool> Register(string FirstName, string LastName, string userName, string email, string password);
        Task Logout();
    }
}
