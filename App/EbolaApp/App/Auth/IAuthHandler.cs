namespace EbolaApp.App
{
    public interface IAuthHandler
    {
        Task<IResult> Register(LoginCommand command);
        Task<IResult> Login(LoginCommand command, HttpContext http);
        Task Logout(HttpContext http);
    }
}
