using FlashCardBlazorApp.DataAccess.Data;
using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.DataAccess.Services.UserService;
using FlashCardBlazorApp.Models.Models;

namespace FlashCardBlazorApp.DataAccess.Services.UserService
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(User user) 
        {
            var userFromDB = _context.Users.FirstOrDefault(u => u.ID == user.ID);
            if (userFromDB == null) return;

            userFromDB.FirstName = user.FirstName;
            userFromDB.LastName = user.LastName;
            userFromDB.Password = user.Password;
            userFromDB.Email = user.Email;
        }
    }
}
