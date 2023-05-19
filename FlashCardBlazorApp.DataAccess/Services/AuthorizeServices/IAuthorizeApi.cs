using FlashCardBlazorApp.Shared;

namespace FlashCardBlazorApp.DataAccess.Services.AuthorizeServices
{
    public interface IAuthorizeApi
    {
        Task Login(LoginParameters loginParameters);
        Task Register(RegisterParameters registerParameters);
        Task Logout();
        Task<UserInfo> GetUserInfo();
    }
}
