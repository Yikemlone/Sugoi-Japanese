using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;

namespace FlashCardBlazorApp.DataAccess.Services.UserOptionsService
{
    public interface IUserOptionsRepository : IRepository<UserFlashCardOptions>
    {
        void Update(UserFlashCardOptions userOptions);
        Task<UserFlashCardOptions> Get(Guid userID);
    }
}
