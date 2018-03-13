namespace LogicCrosswordLearning.CrosswordCreator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("Word")]
    //public partial class Word
    //{
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    //    public Word()
    //    {
    //        WordEntries = new HashSet<WordEntry>();
    //        WordMeanings = new HashSet<WordMeaning>();
    //        WordMeanings1 = new HashSet<WordMeaning>();
    //    }

    //    [Key]
    //    public int Word_ID { get; set; }

    //    [Required]
    //    [StringLength(20)]
    //    public string Value { get; set; }

    //    public int Language_ID { get; set; }

    //    public bool? Archived { get; set; }

    //    public virtual Language Language { get; set; }

    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    //    public virtual ICollection<WordEntry> WordEntries { get; set; }

    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    //    public virtual ICollection<WordMeaning> WordMeanings { get; set; }

    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    //    public virtual ICollection<WordMeaning> WordMeanings1 { get; set; }
    //}

}
