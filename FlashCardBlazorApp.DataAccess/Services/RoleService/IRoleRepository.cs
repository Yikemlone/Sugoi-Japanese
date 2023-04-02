using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;

namespace FlashCardBlazorApp.DataAccess.Services.RoleService
{
    public interface IRoleRepository : IRepository<Role>
    {
        void Update(Role role);
    }
}
