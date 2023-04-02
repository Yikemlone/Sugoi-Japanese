using FlashCardBlazorApp.DataAccess.Services.RepositoryService;
using FlashCardBlazorApp.Models.Models;

namespace FlashCardBlazorApp.DataAccess.Services.VocabProgressService
{
    public interface IVocabProgressRepository : IRepository<VocabProgress>
    {
        void Update(VocabProgress vocabProgress);
    }
}
