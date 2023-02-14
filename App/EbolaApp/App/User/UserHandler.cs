

using System.Security.Claims;

namespace EbolaApp.App
{
    public class UserHandler : IUserHandler
    {
        public UserHandler(ApplicationService service)
        {
            _service = service;
        }
        public async Task<IResult> UpdateUser(UserDto user)
        {
            var data = await _service.UpdateUser(user);
            if(data == null)
                return Results.Problem();
            return Results.Ok(data);
        }
        public async Task<IResult> GetProfiles()
        {
            var users = await _service.GetUsers();
            return Results.Ok(users);
        }
        public async Task<IResult> GetProfile(HttpContext http)
        {
            var email = http.User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrWhiteSpace(email)) return Results.Unauthorized();

            var user = await _service.GetUser(email);
            if (user == null)
                return Results.BadRequest($"User with email: {email} doesn't exits");
            return Results.Ok(user);
        }
        private ApplicationService _service;
    }
}
