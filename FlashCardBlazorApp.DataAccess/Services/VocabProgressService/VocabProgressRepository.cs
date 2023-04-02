using FlashCardBlazorApp.DataAccess.Data;
using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;

namespace FlashCardBlazorApp.DataAccess.Services.VocabProgressService
{
    public class VocabProgressRepository : Repository<VocabProgress>, IVocabProgressRepository
    {
        private readonly ApplicationDbContext _context;

        public VocabProgressRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public void Update(VocabProgress vocabProgress) 
        {
            var vocabProgressFromDB = _context.VocabProgresses.FirstOrDefault(vp => vp.ID == vocabProgress.ID);
            if (vocabProgressFromDB == null) return;

            vocabProgressFromDB.ProgressRating = vocabProgress.ProgressRating;
        }
    }
}
