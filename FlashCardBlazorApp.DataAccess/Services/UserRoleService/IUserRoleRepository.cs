using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;

namespace FlashCardBlazorApp.DataAccess.Services.UserRoleService
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        void Update(UserRole userRole);
    }
}
