using System.ComponentModel.DataAnnotations;

namespace FlashCardBlazorApp.Models.Models
{
    public class VocabProgress
    {
        [Key]
        public int ID { get; set; }

        public int ProgressRating { get; set; }

        public int VocabID { get; set; }
        public Vocab Vocab { get; set; }

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
