namespace EbolaApp.App
{
    public interface IUserHandler
    {
        Task<IResult> UpdateUser(UserDto user);
        Task<IResult> GetProfiles();
        Task<IResult> GetProfile(HttpContext http);
    }
}
