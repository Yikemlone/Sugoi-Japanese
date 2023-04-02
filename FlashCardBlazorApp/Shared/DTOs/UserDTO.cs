using System.ComponentModel.DataAnnotations;

namespace FlashCardBlazorApp.Shared.DTOs
{
    public class UserDTO
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public List<VocabProgressDTO>? VocabProgresses { get; set; }
        public List<UserRoleDTO> UserRoles { get; set; }

    }
}
