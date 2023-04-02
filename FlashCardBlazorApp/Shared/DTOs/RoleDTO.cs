using System.ComponentModel.DataAnnotations;

namespace FlashCardBlazorApp.Shared.DTOs
{
    public class RoleDTO
    {
        [Key]
        public int ID { get; set; }

        public string RoleName { get; set; } = string.Empty;
    }
}
