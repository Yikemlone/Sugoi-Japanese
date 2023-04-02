using FlashCardBlazorApp.DataAccess.Data;
using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;

namespace FlashCardBlazorApp.DataAccess.Services.RoleService
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public void Update(Role role) 
        {
            var roleFromDB = _context.Roles.FirstOrDefault(r => r.ID == role.ID);
            if (roleFromDB == null) return;

            roleFromDB.RoleName = role.RoleName;
        }
    }
}
