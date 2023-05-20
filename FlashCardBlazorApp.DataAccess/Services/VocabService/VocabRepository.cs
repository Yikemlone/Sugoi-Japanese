using FlashCardBlazorApp.DataAccess.Data;
using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardBlazorApp.DataAccess.Services.VocabService
{
    public class VocabRepository : Repository<Vocab>, IVocabRepository
    {
        private readonly ApplicationDbContext _context;

        public VocabRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<Vocab>> Get(int wordsPerSession, List<VocabProgress> vocabProgresses)
        {
            var vocabIDs = vocabProgresses.Select(vp => vp.VocabID).ToList();

            var randomRecords = _context.Vocabs
                .Where(x => !vocabIDs.Contains(x.ID))
                .OrderBy(x => Guid.NewGuid())
                .Take(wordsPerSession)
                .ToList();

            return randomRecords;

            //var vocabIDs = vocabProgresses.Select(vp => vp.VocabID).ToList();
            //var pageSize = 50;

            //var randomRecords = new List<Vocab>();

            //var chunk = _context.Vocabs
            //    .Take(pageSize)
            //    .Where(x => !vocabIDs.Contains(x.ID))
            //    .OrderBy(x => Guid.NewGuid())
            //    .ToList();

            //return randomRecords;
        }

        public void Update(Vocab vocab) 
        {
            var vocabFromDB = _context.Vocabs.FirstOrDefault(v => v.ID == vocab.ID);
            if (vocabFromDB == null) return;

            vocabFromDB.JLPT = vocab.JLPT;

            vocabFromDB.VocabExpression = vocab.VocabExpression;
            vocabFromDB.VocabKana = vocab.VocabKana;
            vocabFromDB.VocabSounds = vocab.VocabSounds;
            vocabFromDB.VocabPos = vocab.VocabPos;

            vocabFromDB.SentenceExpression = vocab.SentenceExpression;
            vocabFromDB.SentenceKana = vocab.SentenceKana;
            vocabFromDB.SentenceMeaning = vocab.SentenceMeaning;
            vocabFromDB.SentenceSound = vocab.SentenceSound;

            vocabFromDB.VocabFurigana = vocab.VocabKana;
            vocabFromDB.SentenceFurigana = vocab.SentenceFurigana;
        }
    }
}
