using FlashCardBlazorApp.DataAccess.Data;
using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardBlazorApp.DataAccess.Services.VocabProgressService
{
    public class VocabProgressRepository : Repository<VocabProgress>, IVocabProgressRepository
    {
        private readonly ApplicationDbContext _context;

        public VocabProgressRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<VocabProgress>> GetAll(Guid userID)
        {
            var vocabProgress = await _context.VocabProgresses
                .Where(u => u.ApplicationUserId == userID)
                .ToListAsync();

            return vocabProgress;
        }

        public async void Update(VocabProgress vocabProgress) 
        {
            var vocabProgressFromDB = _context.VocabProgresses.FirstOrDefault(vp => vp.ID == vocabProgress.ID);
            if (vocabProgressFromDB == null) return;

            vocabProgressFromDB.ProgressRating = vocabProgress.ProgressRating;
        }

        public async Task UpdateRange(List<VocabProgress> vocabProgresses)
        {
            foreach (var vocabProgress in vocabProgresses)
            {
                var vocabProgressFromDB = _context.VocabProgresses.FirstOrDefault(vp => vp.ID == vocabProgress.ID);
                if (vocabProgressFromDB == null) continue;

                vocabProgressFromDB.ProgressRating = vocabProgress.ProgressRating;
            }
        }
    }
}
