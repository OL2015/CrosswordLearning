namespace LogicCrosswordLearning.WordsResource
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WordMeaning")]
    public partial class WordMeaning
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WordMeaning()
        {
            LearnStatistics = new HashSet<LearnStatistic>();
            WordMeaningStatistics = new HashSet<WordMeaningStatistic>();
            WordEntries = new HashSet<WordEntry>();
        }

        [Key]
        public int WordMeaning_ID { get; set; }

        public int MasterWord_ID { get; set; }

        public int TranslateWord_ID { get; set; }

        public int? SpeechPart_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LearnStatistic> LearnStatistics { get; set; }

        public virtual SpeechPart SpeechPart { get; set; }

        public virtual Word Word { get; set; }

        public virtual Word Word1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WordMeaningStatistic> WordMeaningStatistics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WordEntry> WordEntries { get; set; }
    }
}
