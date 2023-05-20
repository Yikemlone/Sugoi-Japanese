using System.ComponentModel.DataAnnotations;

namespace FlashCardBlazorApp.Models.Models
{
    public class UserFlashCardOptions
    {
        [Key]
        public int ID { get; set; }

        public int WordsPerSession { get; set; } = 10;
        public string VocabPosFilter { get; set; } = "All";
        public string JLPT { get; set; } = "All";
        public bool Kanji { get; set; } = true;
        public bool Furigana { get; set; } = true;
        public bool Kana { get; set; } = true;

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

    }
}
