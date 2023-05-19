using FlashCardBlazorApp.DataAccess.Services.UserOptionsService;
using FlashCardBlazorApp.DataAccess.Services.VocabProgressService;
using FlashCardBlazorApp.DataAccess.Services.VocabService;

namespace FlashCardBlazorApp.DataAccess.Services.UnitOfWorkService
{
    public interface IUnitOfWork : IDisposable
    {
        IUserOptionsRepository UserOptionsRepository { get; }
        IVocabProgressRepository VocabProgressRepository { get; }
        IVocabRepository VocabRepository { get; }

        void Save();
    }
}
