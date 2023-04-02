using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;

namespace FlashCardBlazorApp.DataAccess.Services.UserOptionsService
{
    public interface IUserOptionsRepository : IRepository<UserOptions>
    {
        void Update(UserOptions userOptions);
    }
}
