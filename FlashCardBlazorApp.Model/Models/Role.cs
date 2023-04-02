using System.ComponentModel.DataAnnotations;

namespace FlashCardBlazorApp.Models.Models 
{ 
    public class Role
    {
        [Key]
        public int ID { get; set; }

        public string RoleName { get; set; } = string.Empty;
    }
}
