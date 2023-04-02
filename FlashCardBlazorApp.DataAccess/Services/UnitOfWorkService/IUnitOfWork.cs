using FlashCardBlazorApp.DataAccess.Services.RoleService;
using FlashCardBlazorApp.DataAccess.Services.UserOptionsService;
using FlashCardBlazorApp.DataAccess.Services.UserRoleService;
using FlashCardBlazorApp.DataAccess.Services.UserService;
using FlashCardBlazorApp.DataAccess.Services.VocabProgressService;
using FlashCardBlazorApp.DataAccess.Services.VocabService;

namespace FlashCardBlazorApp.DataAccess.Services.UnitOfWorkService
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository RoleRepository { get; }
        IUserOptionsRepository UserOptionsRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IUserRepository UserRepository { get; }
        IVocabProgressRepository VocabProgressRepository { get; }
        IVocabRepository VocabRepository { get; }

        void Save();
    }
}
