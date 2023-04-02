using System.ComponentModel.DataAnnotations;

namespace FlashCardBlazorApp.Models.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public List<VocabProgress>? VocabProgresses { get; set; }
        public List<UserRole> UserRoles { get; set; }

    }
}
