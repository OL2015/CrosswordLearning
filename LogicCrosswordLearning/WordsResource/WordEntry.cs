namespace LogicCrosswordLearning.WordsResource
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WordEntry")]
    public partial class WordEntry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WordEntry()
        {
            WordMeanings = new HashSet<WordMeaning>();
        }

        [Key]
        public int WordEntry_ID { get; set; }

        public int Book_ID { get; set; }

        public int Word_ID { get; set; }

        public int Page { get; set; }

        public DateTime Date { get; set; }

        public virtual Book Book { get; set; }

        public virtual Word Word { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WordMeaning> WordMeanings { get; set; }
    }
}
