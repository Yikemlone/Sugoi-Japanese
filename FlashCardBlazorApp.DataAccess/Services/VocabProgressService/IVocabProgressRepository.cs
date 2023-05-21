using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;

namespace FlashCardBlazorApp.DataAccess.Services.VocabProgressService
{
    public interface IVocabProgressRepository : IRepository<VocabProgress>
    {
        Task<List<VocabProgress>> GetAll(Guid userID);
        void Update(VocabProgress vocabProgress);
    }
}
