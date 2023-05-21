using FlashCardBlazorApp.DataAccess.Data;
using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace FlashCardBlazorApp.DataAccess.Services.VocabService
{
    public class VocabRepository : Repository<Vocab>, IVocabRepository
    {
        private readonly ApplicationDbContext _context;

        public VocabRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<Vocab>> Get(UserFlashCardOptions userFlashCardOptions, List<VocabProgress> vocabProgresses)
        {
            var vocabIDs = vocabProgresses.Select(vp => vp.VocabID).ToList();
            List<Vocab> vocabs = new();
            IQueryable<Vocab> queryable = _context.Vocabs.Select(e => e);

            if (!userFlashCardOptions.JLPT.Equals("All") && !userFlashCardOptions.VocabPosFilter.Equals("All"))
            {
                queryable = queryable
                    .Where(v => v.VocabPos.Equals(userFlashCardOptions.VocabPosFilter) && v.JLPT.Equals(userFlashCardOptions.JLPT));
            }
            else if (!userFlashCardOptions.VocabPosFilter.Equals("All"))
            {
                queryable = queryable.Where(v => v.VocabPos.Equals(userFlashCardOptions.VocabPosFilter));
            }
            else if (!userFlashCardOptions.JLPT.Equals("All"))
            {
                queryable = queryable.Where(v => v.JLPT.Equals(userFlashCardOptions.JLPT));
            }

            vocabs = await queryable
                .Where(x => !vocabIDs.Contains(x.ID))
                .OrderBy(x => Guid.NewGuid())
                .Take(userFlashCardOptions.WordsPerSession)
                .ToListAsync();

            return vocabs;
        }

        public async Task<List<Vocab>> GetRatingVocabs(int rating, List<VocabProgress> vocabProgresses)
        {
            List<int> vocabIDs = new();

            if (rating == 3)
            {
                vocabIDs = vocabProgresses.Select(vp => vp.VocabID).ToList();
            }
            else 
            {
                vocabIDs = vocabProgresses.Where(vp => vp.ProgressRating == rating).Select(vp => vp.VocabID).ToList();
            }

            List<Vocab> vocabs = new();

            IQueryable<Vocab> queryable =  _context.Vocabs
                .AsNoTracking()
                .Where(v => vocabIDs.Contains(v.ID))
                .Select(e => e);

            vocabs = await queryable.ToListAsync();

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
