using FlashCardBlazorApp.DataAccess.Data;
using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;

namespace FlashCardBlazorApp.DataAccess.Services.UserRoleService
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(UserRole userRole) 
        {
            var roleFromDB = _context.UserRoles.FirstOrDefault(r => r.ID == userRole.ID);
            if (roleFromDB == null) return;

            roleFromDB.Role = userRole.Role;
        }
    }
}
