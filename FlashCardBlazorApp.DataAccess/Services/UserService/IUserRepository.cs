using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;

namespace FlashCardBlazorApp.DataAccess.Services.UserService
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
    }
}
