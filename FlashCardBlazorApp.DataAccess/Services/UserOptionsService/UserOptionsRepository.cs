using FlashCardBlazorApp.DataAccess.Data;
using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardBlazorApp.DataAccess.Services.UserOptionsService
{
    public class UserOptionsRepository : Repository<UserFlashCardOptions>, IUserOptionsRepository
    {
        private readonly ApplicationDbContext _context;

        public UserOptionsRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<UserFlashCardOptions> Get(Guid userID)
        {
            return await _context.UserFlashCardOptions
                .Where(uo => uo.ApplicationUserId == userID)
                .FirstOrDefaultAsync();
        }

        public void Update(UserFlashCardOptions userOptions) 
        {
            var optionsFromDB = _context.UserFlashCardOptions.FirstOrDefault(u => u.ID == userOptions.ID);
            if (optionsFromDB == null) return;

            optionsFromDB.WordsPerSession = userOptions.WordsPerSession;
            optionsFromDB.VocabPosFilter = userOptions.VocabPosFilter;
            optionsFromDB.JLPT = userOptions.JLPT;
            optionsFromDB.Furigana = userOptions.Furigana;
            optionsFromDB.Kana = userOptions.Kana;
            optionsFromDB.Kanji = userOptions.Kanji;
        } 
    }
}
