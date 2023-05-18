using System.ComponentModel.DataAnnotations;

namespace FlashCardBlazorApp.Models.Models
{
    public class Vocab
    {
        [Key]
        public int ID { get; set; }

        public string JLPT { get; set; } = string.Empty;

        public string VocabExpression { get; set; } = string.Empty;
        public string VocabKana { get; set; } = string.Empty;
        public string VocabMeaning { get; set; } = string.Empty;
        public string VocabSounds { get; set; } = string.Empty;
        public string VocabPos { get; set; } = string.Empty;

        public string SentenceExpression { get; set; } = string.Empty;  
        public string SentenceKana { get; set; } = string.Empty;
        public string SentenceMeaning { get; set; } = string.Empty;
        public string SentenceSound { get; set; } = string.Empty;

        public string VocabFurigana { get; set; } = string.Empty;
        public string SentenceFurigana { get; set; } = string.Empty;

        public List<VocabProgress>? VocabProgresses { get; set; }
    }
}
