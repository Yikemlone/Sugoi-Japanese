using System.ComponentModel.DataAnnotations;

namespace FlashCardBlazorApp.Shared.DTOs
{
    public class UserOptionsDTO
    {
        [Key]
        public int ID { get; set; }

        public int? UserID { get; set; }
        public UserDTO? User { get; set; }

        public int WordsPerSession { get; set; }
        public string VocabPosFilter { get; set; } = string.Empty;
        public string JLPT { get; set; } = string.Empty;
        public bool Kanji { get; set; }
        public bool Furigana { get; set; }
        public bool Kana { get; set; }

    }
}
