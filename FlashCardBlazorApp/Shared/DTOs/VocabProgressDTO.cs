using System.ComponentModel.DataAnnotations;

namespace FlashCardBlazorApp.Shared.DTOs
{
    public class VocabProgressDTO
    {
        [Key]
        public int ID { get; set; }

        public int ProgressRating { get; set; }

        public int VocabID { get; set; }
        public VocabDTO Vocab { get; set; }

        public int UserID { get; set; }
        public UserDTO User { get; set; }
    }
}
