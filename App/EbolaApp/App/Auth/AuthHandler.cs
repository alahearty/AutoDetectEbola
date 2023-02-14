using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace EbolaApp.App
{
    public class AuthHandler : IAuthHandler
    {
        public AuthHandler(ApplicationService service)
        {
            _service = service;
        }
        public async Task<IResult> Register(LoginCommand command)
        {
            if (!Utils.IsValidCredentials(command.Email,command.Password))
                return Results.BadRequest();

            var dbOperation = await _service.AddUser(command.Email, command.Password);
            if (dbOperation)
                return Results.Ok();
            return Results.StatusCode(500);
        }
        public async Task<IResult> Login(LoginCommand command, HttpContext http)
        {
            if (!Utils.IsValidCredentials(command.Email, command.Password)) return Results.BadRequest("command cannot be null.");

            var users = await _service.DbContext.Users.ToListAsync();
            var user = users.Where(x => x.Email.ToUpper() == command.Email.ToUpper() && Utils.VerifyPassword(command.Password, x.Password))
                            .FirstOrDefault();

            if (user == null)
                return Results.BadRequest("User not found.");

            await AddClaims(http, user);

            var dto = await _service.GetUser(command.Email);
            return Results.Ok(dto);

        }

        public async Task Logout(HttpContext http)
        {
            await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        private async Task AddClaims(HttpContext http, User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var principalUser = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
            await http.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principalUser,
               new AuthenticationProperties
               {
                   ExpiresUtc = DateTime.UtcNow.AddMinutes(5),
                   IssuedUtc = DateTime.UtcNow,
                   IsPersistent = false,
                   AllowRefresh = false,
               });
        }
        private ApplicationService _service;

       
    }
}
