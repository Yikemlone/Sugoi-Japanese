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
            var vocabs = new List<Vocab>();

            while (vocabs.Count < wordsPerSession)
            {
                var batchVocabs = await _context.Vocabs
                    .Where(v => !vocabIDs.Contains(v.ID) && !vocabs.Select(vc => vc.ID).Contains(v.ID))
                    .OrderBy(t => Guid.NewGuid())
                    .Take(wordsPerSession - vocabs.Count)
                    .ToListAsync();

                vocabIDs.AddRange(batchVocabs.Select(bv => bv.ID));
                vocabs.AddRange(batchVocabs);
            }

            return vocabs;
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
