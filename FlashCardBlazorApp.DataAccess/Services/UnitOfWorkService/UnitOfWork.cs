using FlashCardBlazorApp.DataAccess.Data;
using FlashCardBlazorApp.DataAccess.Services.RoleService;
using FlashCardBlazorApp.DataAccess.Services.UserOptionsService;
using FlashCardBlazorApp.DataAccess.Services.UserRoleService;
using FlashCardBlazorApp.DataAccess.Services.UserService;
using FlashCardBlazorApp.DataAccess.Services.VocabProgressService;
using FlashCardBlazorApp.DataAccess.Services.VocabService;

namespace FlashCardBlazorApp.DataAccess.Services.UnitOfWorkService
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRoleRepository RoleRepository { get; private set; }
        public IUserOptionsRepository UserOptionsRepository { get; private set; }
        public IUserRoleRepository UserRoleRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IVocabProgressRepository VocabProgressRepository { get; private set; }
        public IVocabRepository VocabRepository { get; private set; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
            RoleRepository = new RoleRepository(_context);
            UserOptionsRepository = new UserOptionsRepository(_context);
            UserRoleRepository = new UserRoleRepository(_context);
            UserRepository = new UserRepository(_context);
            VocabProgressRepository = new VocabProgressRepository(_context);
            VocabRepository = new VocabRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
