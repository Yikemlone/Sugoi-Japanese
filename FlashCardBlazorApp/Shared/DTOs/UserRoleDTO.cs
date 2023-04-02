using System.ComponentModel.DataAnnotations;

namespace FlashCardBlazorApp.Shared.DTOs
{
    public class UserRoleDTO
    {
        [Key]
        public int ID { get; set; }

        public int UserID { get; set; }
        public UserDTO User { get; set; }

        public int RoleID { get; set; }
        public RoleDTO Role { get; set; }

    }
}
