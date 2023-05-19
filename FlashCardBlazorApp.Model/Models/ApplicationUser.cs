using Microsoft.AspNetCore.Identity;

namespace FlashCardBlazorApp.Models.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public List<VocabProgress> VocabProgresses { get; set; } = new();

        public int? UserFlashCardOptionsID { get; set; }
        public UserFlashCardOptions? UserFlashCardOptions { get; set; } = new();
    }
}
