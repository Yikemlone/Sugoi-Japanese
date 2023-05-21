using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;

namespace FlashCardBlazorApp.DataAccess.Services.VocabService
{
    public interface IVocabRepository : IRepository<Vocab>
    {
        void Update(Vocab vocab);
        Task<List<Vocab>> Get(UserFlashCardOptions userFlashCardOptions, List<VocabProgress> vocabProgresses);
        Task<List<Vocab>> GetRatingVocabs(int rating, List<VocabProgress> vocabProgresses);
    }
}
