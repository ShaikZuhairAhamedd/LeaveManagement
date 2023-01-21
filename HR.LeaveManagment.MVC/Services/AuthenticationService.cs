using HR.LeaveManagment.MVC.Contracts;
using HR.LeaveManagment.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace HR.LeaveManagment.MVC.Services
{
    public class AuthenticationService : BaseHttpService, Contracts.IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private  JwtSecurityTokenHandler _jwtSercurityTokenHandler;

        public AuthenticationService(IClient client, ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor) : base(client, localStorage)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtSercurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthRequest authenticationRequest = new AuthRequest { Email = email, Password = password };
                var authenticationResponse = await _client.LoginAsync(authenticationRequest);
                if (authenticationResponse.Token != string.Empty)
                {

                    var tokenContent = _jwtSercurityTokenHandler.ReadJwtToken(authenticationResponse.Token);
                    var claims = tokenContent.Claims.ToList();
                    claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
                    var claimPrinciple = new ClaimsPrincipal(new ClaimsIdentity[] { new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme) });
                    await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrinciple);
                    _localStorage.SetStorageValue("token", authenticationResponse.Token);
                    return true;
                }
                return false;
            }
            catch(Exception ex) {
                return false;
            }
        }

        public async Task Logout()
        {
            _localStorage.ClearStorage(new List<string> { "token"});
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> Register(string FirstName, string LastName, string userName, string email, string password)
        {
            var registrationRequest = new RegistrationRequest
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = email,
                UserName = userName,
                Password = password
            };

            var response = await _client.RegisterAsync(registrationRequest);
            if (!string.IsNullOrEmpty(response.Id)) 
            {
                return true;
            }

            return false;
        }
    }
}
