using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Modals.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await authService.Login(request));
        }
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegistrationRequest request)
        {
            return Ok(await authService.Register(request));
        }
    }
}
