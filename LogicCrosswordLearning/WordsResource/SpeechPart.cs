namespace LogicCrosswordLearning.WordsResource
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SpeechPart")]
    public partial class SpeechPart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SpeechPart()
        {
            WordMeanings = new HashSet<WordMeaning>();
        }

        [Key]
        public int SpeechPart_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string NameEng { get; set; }

        [Required]
        [StringLength(15)]
        public string NameUkr { get; set; }

        [Required]
        [StringLength(10)]
        public string ShortEng { get; set; }

        [Required]
        [StringLength(10)]
        public string ShortUkr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WordMeaning> WordMeanings { get; set; }
    }
}
